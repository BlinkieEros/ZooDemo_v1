using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooDemoExam.Forms;
using ZooDemoExam.Properties;

namespace ZooDemoExam
{

    

    public partial class OrderUC : UserControl
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Pickup { get; set; }
        public string Role { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public OrderUC()
        {
            InitializeComponent();
        }

        public void SetLabels()
        {
            lblArticle.Text = "Артикул: " + Article;
            lblStatus.Text = "Статус: " + Status;
            lblOrder.Text = "Дата заказа: " + OrderDate.ToString("dd.MM.yyyy");
            lblDelivery.Text = "Дата доставки: " + DeliveryDate.ToString("dd.MM.yyyy");
            lblPickup.Text = "Адрес: " + Pickup;


            if (Role != "Администратор")
            {
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                btnEdit.Visible = true;
            }
        }


       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                {
                    connection.Open();
                    var result = MessageBox.Show("Вы точно уверены в удалении заказа?", "Удалить заказ", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        using (NpgsqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                {
                                    string sqlItem = "Delete from order_items where fk_order = @fk_order";
                                    using (NpgsqlCommand command1 = new NpgsqlCommand(sqlItem, connection, transaction))
                                    {
                                    command1.Parameters.AddWithValue("@fk_order",Id);
                                    command1.ExecuteNonQuery();
                                    }


                                    string sqlOrder = "Delete from \"order\" where id_order = @Id";
                                    using (NpgsqlCommand command2 = new NpgsqlCommand(sqlOrder, connection, transaction))
                                    {
                                        command2.Parameters.AddWithValue("@Id", Id);
                                        command2.ExecuteNonQuery();
                                    }

                                    transaction.Commit();
                                    MessageBox.Show("Заказ каскадно удалён", "Успех!", MessageBoxButtons.OK);
                                    this.Parent.Controls.Remove(this);
                                    
                                }
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }  
                        }
                    }

                    else
                    {
                        return;
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
            var form = new OrderAddForm(this);

            if (form.ShowDialog() == DialogResult.OK)
            {

                this.SetLabels();
                

            }
        }
    }
}
