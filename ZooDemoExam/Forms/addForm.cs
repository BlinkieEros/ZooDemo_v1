using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using ZooDemoExam.Properties;
namespace ZooDemoExam
{
    public partial class addForm : Form
    {
        string photoPath;
        string photoName;
        private ProductUC _productControl;
        public addForm()
        {
            InitializeComponent();
            this.Text = "Добавление товара";
            lblLabel.Text = "Добавление товара";
        }
        
        public addForm(ProductUC productControl)
        {
            InitializeComponent();
            _productControl = productControl;

            this.Text = "Редактирование товара";
            lblLabel.Text = "Редактирование товара";
            LoadText();
        }

        private void LoadText()
        {
            txtName.Text = _productControl.Name;
            cmbCategory.SelectedItem = _productControl.Category;
            cmbSupplier.SelectedItem = _productControl.Supplier;
            cmbProducer.SelectedItem = _productControl.Producer;
            cmbMeasure.SelectedItem = _productControl.Measure;
            numPrice.Value = Convert.ToDecimal(_productControl.Price);
            numSale.Value = Convert.ToInt32(_productControl.Discount);
            numQuantity.Value = Convert.ToInt32(_productControl.Quantity);
            txtDesc.Text = _productControl.Description;
            pictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "images", _productControl.Photo);   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Все Файлы|*.*";
                ofd.Title = "Выберите фотографию";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    photoPath = ofd.FileName;
                    photoName = Path.GetFileName(photoPath);
                    string truePath = Path.Combine(Application.StartupPath, "images", photoName);
                    File.Copy(photoPath, truePath, true);
                    pictureBox1.ImageLocation = truePath;
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_productControl != null) 
            {
                _productControl.Name = txtName.Text;
                _productControl.Category = (string)cmbCategory.SelectedItem;
                _productControl.Supplier = (string)cmbSupplier.SelectedItem;
                _productControl.Producer = (string)cmbProducer.SelectedItem;
                _productControl.Measure = (string)cmbMeasure.SelectedItem;
                _productControl.Price = (double)numPrice.Value;
                _productControl.Discount = (int)numSale.Value;
                _productControl.Quantity = (int)numQuantity.Value;
                _productControl.Description = txtDesc.Text;
                if (!string.IsNullOrEmpty(photoName))
                {
                    _productControl.Photo = photoName;
                }

                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                    {
                        connection.Open();
                        string sql = @"UPDATE public.product 
                SET product_name=@product_name, fk_measure=@fk_measure, 
                price=@price, fk_supplier=@fk_supplier, fk_producer=@fk_producer, fk_category=@fk_category, 
                sale=@sale, quantity_product=@quantity, desc_product=@desc, photo_product=@photo WHERE article = @article;";

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@article", _productControl.Article);
                            command.Parameters.AddWithValue("@product_name", txtName.Text);
                            command.Parameters.AddWithValue("@fk_measure", cmbMeasure.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@fk_supplier", cmbSupplier.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@fk_producer", cmbProducer.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@fk_category", cmbCategory.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@price",numPrice.Value);
                            command.Parameters.AddWithValue("@sale", numSale.Value);
                            command.Parameters.AddWithValue("@quantity", numQuantity.Value);
                            command.Parameters.AddWithValue("@desc", txtDesc.Text);
                            command.Parameters.AddWithValue("@photo",
                                    string.IsNullOrEmpty(_productControl.Photo) ? (object)DBNull.Value : _productControl.Photo);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Товар успешно обновлён", "Успех!");

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message, "неприятнось");
                }
            }
            
           else 
           {

                try
                {


                    using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                    {
                        connection.Open();
                        string sql = @"INSERT INTO public.product(product_name, fk_measure, price, fk_supplier, fk_producer, fk_category, sale, quantity_product, desc_product, photo_product) 
                        VALUES (@product_name, @fk_measure, @price, @fk_supplier, @fk_producer, @fk_category, @sale, @quantity_product, @desc_product, @photo_product);";

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@product_name", txtName.Text);
                            command.Parameters.AddWithValue("@fk_measure", cmbMeasure.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@price", numPrice.Value);
                            command.Parameters.AddWithValue("@fk_supplier", cmbSupplier.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@fk_producer", cmbProducer.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@fk_category", cmbCategory.SelectedIndex + 1);
                            command.Parameters.AddWithValue("@sale", numSale.Value);
                            command.Parameters.AddWithValue("@quantity_product", numQuantity.Value);
                            command.Parameters.AddWithValue("@desc_product", txtDesc.Text);
                            command.Parameters.AddWithValue("@photo_product",
                                string.IsNullOrEmpty(photoName) ? (object)DBNull.Value : photoName);
                            command.ExecuteNonQuery();

                        }
                    }
                    MessageBox.Show("Успешное добавление товара!", "Успех!", MessageBoxButtons.OK);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }

        }

        
    }
}
