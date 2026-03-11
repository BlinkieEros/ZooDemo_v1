using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class ProductUC : UserControl
    {
        public string Article { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer {  get; set; }
        public string Supplier { get; set; }
        public string Measure {  get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public int Discount { get; set; }
        public string Photo { get; set; }
        //ссанная роль, бился над ней час
        public string Role { get; set; }
        


        public ProductUC()
        {
            InitializeComponent();
            
        }
    
        public void SetLabels()
        {
            
            lblName.Text = Name + " | " + Category;
            lblDesc.Text = Description;
            lblProducer.Text = "Производитель: " + Producer;
            lblSupplier.Text = "Поставщик: "+ Supplier;
            lblPrice.Text = "Цена: " + Price.ToString() + " руб.";
            lblTotal.Text = "Итоговая цена: " + Total.ToString() + " руб.";
            lblSale.Text = "Скидка: " + Discount.ToString() + "%";
            lblMeasure.Text = "Единица измерения: "+ Measure;



            //бля похуй, я хз че тут. Тут вроде заглушка должна вылетать но чё-та не работает
            if (Photo == "placeholder.jpg")
            {
                pictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "images", "placeholder.jpg");
            }

            else
            {
                pictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "images", Photo);
            }
            
            if (Discount > 15)
                panel1.ForeColor = ColorTranslator.FromHtml("#67D31D");
            if (Discount != 0)
            {
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Strikeout);
                lblPrice.ForeColor = Color.Red;
            }
            if (Discount == 0)
            {
                
            lblTotal.Visible = false;
            }
            lblQuantity.Text = "Кол-во на складе: " + Quantity.ToString();
            if (Quantity == 0)
            {
                lblQuantity.ForeColor = Color.Cyan;
            }


            

        }

        public void UserPerms()
        { 
            if (Role != "Администратор")
            { 
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                // Если админ — показываем
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                {
                    connection.Open();
                    var result = MessageBox.Show("Вы точно уверены в удалении товара?", "Удалить товар", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string sql1 = "SELECT EXISTS (select 1 from order_items where fk_article = @article)";
                        using (NpgsqlCommand command1 = new NpgsqlCommand(sql1,connection))
                        {
                            command1.Parameters.AddWithValue("@article", this.Article);
                            if ((bool)command1.ExecuteScalar())
                            {
                                MessageBox.Show("Невозможно удалить товар, так как он присутствует в заказах", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else 
                            {
                                string article = this.Article;
                                string sql = "DELETE FROM product WHERE article = @article";
                                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                                {
                                    command.Parameters.AddWithValue("@article", article);
                                    command.ExecuteNonQuery();
                                }
                                MessageBox.Show("Успешно удалён товар", "Успех!", MessageBoxButtons.OK);
                                this.Parent.Controls.Remove(this);

                            }
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception ex)  
            { 
            MessageBox.Show("Ошибка:" + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editForm = new addForm(this);

            if (editForm.ShowDialog() == DialogResult.OK)
            {

                this.SetLabels();


            }
            
        }
    }
}
