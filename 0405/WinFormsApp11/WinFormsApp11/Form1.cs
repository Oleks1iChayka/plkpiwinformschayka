using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp11
{
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();
        List<CartItem> cart = new List<CartItem>();

        ListBox lstProducts;
        DataGridView dgvCart;
        Button btnAdd, btnCheckout, btnUpdateQty, btnRemove;
        NumericUpDown numQuantity;
        Label lblTotal;

        public Form1()
        {
            this.Text = "Міні-магазин із редагуванням кошика";
            this.Size = new Size(850, 550);

            // Ініціалізація інтерфейсу
            lstProducts = new ListBox { Location = new Point(10, 30), Size = new Size(250, 300) };
            dgvCart = new DataGridView
            {
                Location = new Point(280, 30),
                Size = new Size(530, 300),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            numQuantity = new NumericUpDown { Location = new Point(10, 340), Width = 60, Minimum = 1, Value = 1 };

            btnAdd = new Button { Text = "Додати в кошик", Location = new Point(80, 338), Width = 180, BackColor = Color.LightGreen };
            btnUpdateQty = new Button { Text = "Оновити кількість у кошику", Location = new Point(280, 338), Width = 200 };
            btnRemove = new Button { Text = "Видалити", Location = new Point(490, 338), Width = 100, BackColor = Color.MistyRose };
            btnCheckout = new Button { Text = "ОФОРМИТИ ЗАМОВЛЕННЯ", Location = new Point(280, 380), Size = new Size(530, 40), Font = new Font(this.Font, FontStyle.Bold) };

            lblTotal = new Label { Text = "Разом: 0 грн", Location = new Point(650, 345), AutoSize = true, Font = new Font("Arial", 12) };

            this.Controls.AddRange(new Control[] {
                new Label { Text = "Склад товарів:", Location = new Point(10, 10) },
                new Label { Text = "Ваш кошик:", Location = new Point(280, 10) },
                lstProducts, dgvCart, numQuantity, btnAdd, btnUpdateQty, btnRemove, btnCheckout, lblTotal
            });

            LoadProducts();

            // ПОДІЇ
            btnAdd.Click += BtnAdd_Click;
            btnUpdateQty.Click += BtnUpdateQty_Click;
            btnRemove.Click += BtnRemove_Click;
            btnCheckout.Click += BtnCheckout_Click;

            // Коли клікаємо на рядок у кошику — підтягуємо його кількість у лічильник
            dgvCart.SelectionChanged += (s, e) => {
                if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index < cart.Count)
                {
                    numQuantity.Value = cart[dgvCart.CurrentRow.Index].Quantity;
                }
            };
        }

        private void LoadProducts()
        {
            products.Add(new Product { Name = "Ноутбук", Price = 25000, Stock = 5 });
            products.Add(new Product { Name = "Мишка", Price = 600, Stock = 20 });
            products.Add(new Product { Name = "Монітор", Price = 8000, Stock = 4 });
            lstProducts.DataSource = products;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItem is Product p)
            {
                int qty = (int)numQuantity.Value;

                if (qty > p.Stock)
                {
                    MessageBox.Show($"Недостатньо на складі! Максимум: {p.Stock}");
                    return;
                }

                var existing = cart.FirstOrDefault(x => x.Name == p.Name);
                if (existing != null)
                {
                    if (existing.Quantity + qty > p.Stock)
                    {
                        MessageBox.Show("Загальна кількість перевищить склад!");
                        return;
                    }
                    existing.Quantity += qty;
                }
                else
                {
                    cart.Add(new CartItem { Name = p.Name, Price = p.Price, Quantity = qty, SourceProduct = p });
                }
                UpdateCartUI();
            }
        }

        private void BtnUpdateQty_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                int index = dgvCart.CurrentRow.Index;
                int newQty = (int)numQuantity.Value;
                var item = cart[index];

                if (newQty > item.SourceProduct.Stock)
                {
                    MessageBox.Show($"На складі лише {item.SourceProduct.Stock} шт.");
                    return;
                }

                item.Quantity = newQty;
                UpdateCartUI();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                cart.RemoveAt(dgvCart.CurrentRow.Index);
                UpdateCartUI();
            }
        }

        private void UpdateCartUI()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cart.Select(c => new { c.Name, c.Price, c.Quantity, c.Total }).ToList();
            lblTotal.Text = $"Разом: {cart.Sum(x => x.Total)} грн";
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (!cart.Any()) return;

            string receipt = $"ЧЕК ЗА {DateTime.Now}\n" + string.Join("\n", cart.Select(c => $"{c.Name} x{c.Quantity} = {c.Total} грн"));

            // Зменшуємо склад
            foreach (var item in cart)
            {
                item.SourceProduct.Stock -= item.Quantity;
            }

            File.WriteAllText("receipt.txt", receipt);
            MessageBox.Show("Замовлення оформлено! Чек збережено.");

            cart.Clear();
            UpdateCartUI();
            lstProducts.DataSource = null;
            lstProducts.DataSource = products; // Оновлюємо склад у списку
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public override string ToString() => $"{Name} - {Price} грн (Склад: {Stock})";
    }

    public class CartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
        public Product SourceProduct { get; set; } // Посилання на товар на складі
    }
}