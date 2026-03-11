using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooDemoExam.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZooDemoExam.Forms
{
    public partial class OrderAddForm : Form
    {
        private OrderUC _order;
        public OrderAddForm()
        {
            InitializeComponent();
            this.Text = "Добавить заказ";
            lblLabel.Text = "Добавление заказа";
            cmbStatus.SelectedIndex = 1;
        }

        public OrderAddForm(OrderUC order)
        {
            InitializeComponent();
            _order = order;
            this.Text = "Редактировать заказ";
            lblLabel.Text = "Редактирование заказа";
            LoadText();
        }








        private void LoadText()
        {
            cmbArticle.SelectedItem = _order.Article;
            cmbPickup.SelectedItem = _order.Pickup;
            numQuantity.Value = _order.Quantity;
            cmbName.SelectedItem = _order.Name;
            cmbStatus.SelectedItem = _order.Status;
            dateTimePickerDelivery.Value = _order.DeliveryDate;
            dateTimePickerOrder.Value = _order.OrderDate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_order != null)
            {
               _order.Article = cmbArticle.Text;
                _order.Status = cmbStatus.Text;
                _order.OrderDate = dateTimePickerOrder.Value;
                _order.DeliveryDate = dateTimePickerDelivery.Value;
                _order.Pickup = cmbPickup.Text;
                _order.Role = "Администратор";
                try
                {
                   using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                    {
                        connection.Open();
                        using (NpgsqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                string sqlOrder = "UPDATE public.\"order\" SET date_order=@date_order, date_delivery=@date_delivery, fk_pickup=@fk_pickup, fk_user=@fk_user, fk_status=@fk_status WHERE id_order = @id;";
                                using (NpgsqlCommand cmd1 = new NpgsqlCommand(sqlOrder, connection, transaction)) 
                                {
                                    cmd1.Parameters.AddWithValue("@id", _order.Id);
                                    cmd1.Parameters.AddWithValue("@date_order", dateTimePickerOrder.Value);
                                    cmd1.Parameters.AddWithValue("@date_delivery", dateTimePickerDelivery.Value);
                                    cmd1.Parameters.AddWithValue("@fk_pickup", cmbPickup.SelectedIndex + 1);
                                    cmd1.Parameters.AddWithValue("@fk_user", cmbName.SelectedIndex + 1);
                                    cmd1.Parameters.AddWithValue("@fk_status", cmbStatus.SelectedIndex + 1);
                                    cmd1.ExecuteNonQuery();
                                }


                                string sqlOrderItems = "UPDATE public.order_items SET fk_article=@fk_article, quantity_order=@quantity_order WHERE fk_order = @id;";
                                using (NpgsqlCommand cmd2 = new NpgsqlCommand(sqlOrderItems, connection, transaction))
                                {
                                    cmd2.Parameters.AddWithValue("@id", _order.Id);
                                    cmd2.Parameters.AddWithValue("@fk_article", cmbArticle.Text);
                                    cmd2.Parameters.AddWithValue("@quantity_order", numQuantity.Value);
                                    cmd2.ExecuteNonQuery();
                                }
                                transaction.Commit();
                                MessageBox.Show("Заказ успешно обновлен", "Успех!", MessageBoxButtons.OK);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                return;
                            }
                            catch 
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка!");
                }
            }
            else
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                    {
                        connection.Open();
                        using (NpgsqlTransaction transaction = connection.BeginTransaction())
                        { 
                        try 
                        {
                             string sqlOrder = @"INSERT INTO public.""order""(
	                                    date_order, date_delivery, fk_pickup, fk_user, fk_status)
	                                    VALUES (@date_order, @date_delivery, @fk_pickup, @fk_user, @fk_status) returning id_order;";
                                int orderId;
                                using (NpgsqlCommand cmd1 = new NpgsqlCommand(sqlOrder, connection, transaction))
                                {
                                    
                                    cmd1.Parameters.AddWithValue("@date_order", dateTimePickerOrder.Value);
                                    cmd1.Parameters.AddWithValue("@date_delivery", dateTimePickerDelivery.Value);
                                    cmd1.Parameters.AddWithValue("@fk_pickup", cmbPickup.SelectedIndex + 1);
                                    cmd1.Parameters.AddWithValue("@fk_user", cmbName.SelectedIndex + 1);
                                    cmd1.Parameters.AddWithValue("@fk_status", cmbStatus.SelectedIndex + 1);
                                    orderId = Convert.ToInt32(cmd1.ExecuteScalar());

                                }

                                string sqlOrderItems = "INSERT INTO public.order_items(fk_order, fk_article, quantity_order) VALUES (@fk_order, @fk_article, @quantity_order);";
                                using (NpgsqlCommand cmd2 =  new NpgsqlCommand(sqlOrderItems, connection, transaction))
                                {
                                    cmd2.Parameters.AddWithValue("@fk_order", orderId);
                                    cmd2.Parameters.AddWithValue("@fk_article", cmbArticle.Text);
                                    cmd2.Parameters.AddWithValue("@quantity_order", numQuantity.Value);
                                    cmd2.ExecuteNonQuery();
                                }
                                transaction.Commit();
                                MessageBox.Show("Успешно добавлен заказ.", "Успех!", MessageBoxButtons.OK);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                return;


                        }
                            catch 
                            {
                                transaction.Rollback();
                                throw;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка:" + ex.Message, "Ошибка!");
                }
            }
        }
    }
}
