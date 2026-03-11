using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooDemoExam.Forms;
using ZooDemoExam.Properties;

namespace ZooDemoExam
{
    public partial class MainForm : Form
    {
        public string CurrentRole { get; set; }
        public string Supplier { get; set; }
        public string Course { get; set; }
        public string Search { get; set; }
        public MainForm(AuthForm authForm) //string Role, string Name туда всунь
        {
            InitializeComponent();

            string _name = authForm.Name;
            this.CurrentRole = authForm.Role;
            lblName.Text = _name;
            cmbFilter.SelectedItem = "Все поставщики";
            this.Supplier = (string)cmbFilter.SelectedItem;
            this.Course = "ASC";
            this.Search = txtSearch.Text;
            Product(this.Search, this.Supplier, this.Course);
            switch (CurrentRole)
            {
                case "Авторизированный клиент":
                case "Гость":
                    txtSearch.Visible = false;
                    cmbFilter.Visible = false;
                    radioAsc.Visible = false;
                    radioDesc.Visible = false;
                    lblSearch.Visible = false;
                    lblFilter.Visible = false;
                    btnAdd.Visible = false;
                    btnOrder.Visible = false;

                    break;

                case "Менеджер":
                    btnAdd.Visible = false;
                    break;

            }
            

            


        }
            
        public void Product(string search, string supplier, string course)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                {
                    flowLayoutPanel1.Controls.Clear();
                    connection.Open();

                    if (string.IsNullOrWhiteSpace(course)) course = "ASC";
            course = course.Trim().ToUpper();
            if (course != "ASC" && course != "DESC") course = "ASC";

                    string query = $@"SELECT article, product_name, me.measure_unit, price, s.supplier_name, p.producer_name, c.category_name, sale, quantity_product, desc_product, photo_product,
	                            ROUND (price *(100-sale)/100,2) as total_price
	                            FROM public.product
                            JOIN public.measure me ON me.id_measure = product.fk_measure
                            join public.supplier s ON s.id_supplier = product.fk_supplier
                            join public.producer p ON p.id_producer = product.fk_producer
                            join public.category c ON c.id_category = product.fk_category
                             {(search != "" || supplier != "Все поставщики" ? "WHERE " : "")}    
                            {(search != "" ? $"(product_name ILIKE '%{search}%' " + 
                            $"OR s.supplier_name ILIKE '%{search}%' " +
                            $"OR p.producer_name ILIKE '%{search}%'" +
                            $"OR c.category_name ILIKE '%{search}%'" +
                            $"OR desc_product ILIKE '%{search}%')" : "")}
                            {(search != "" && supplier != "Все поставщики" ? "AND" : "")}
                            {(supplier != "Все поставщики" ? $"s.supplier_name = '{supplier}'" : "")}
                             ORDER BY sale {(course)};";


                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                ProductUC product = new ProductUC();
                                product.Role = this.CurrentRole;
                                product.Article = reader.GetString(0);
                                product.Name = reader.GetString(1);
                                product.Measure = reader.GetString(2);
                                product.Price = reader.GetDouble(3);
                                product.Supplier = reader.GetString(4);
                                product.Producer = reader.GetString(5);
                                product.Category = reader.GetString(6);
                                product.Discount = reader.GetInt32(7);
                                product.Quantity = reader.GetInt32(8);
                                product.Description = reader.GetString(9);
                                product.Photo = reader.IsDBNull(10) ? "placeholder.jpg" : reader.GetString(10);
                                product.Total = reader.GetDouble(11);
                                product.SetLabels();
                                product.UserPerms();
                                flowLayoutPanel1.Controls.Add(product);

                            }
                        }
                        flowLayoutPanel1.ResumeLayout(false);
                        flowLayoutPanel1.PerformLayout();
                        connection.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message,"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            AuthForm form = new AuthForm();
            form.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new addForm())
            {

                if (addForm.ShowDialog() == DialogResult.OK)
                {

                    Product(this.Search, this.Supplier, this.Course);
                    radioAsc.Checked = true;
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            
            var form = new OrderForm(this);
            
            form.Show();
            
        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Supplier = (string)cmbFilter.SelectedItem;
            Product(this.Search, this.Supplier, this.Course);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.Search = txtSearch.Text;
            Product(this.Search, this.Supplier, this.Course);
        }

        private void radioAsc_CheckedChanged(object sender, EventArgs e)
        {
            this.Course = "ASC";
            Product(this.Search, this.Supplier, this.Course);
        }

        private void radioDesc_CheckedChanged(object sender, EventArgs e)
        {
            this.Course = "DESC";
            Product(this.Search, this.Supplier, this.Course);
        }
    }
}
