using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooDemoExam.Properties;

namespace ZooDemoExam.Forms
{
    public partial class OrderForm : Form
    {
        public string ThisRole { get; set; }
        public OrderForm(MainForm mainForm)
        {
            this.ThisRole = mainForm.CurrentRole;
            InitializeComponent();
            Order();
            
            
            if (ThisRole != "Администратор")
            {
                btnAddOrder.Visible = false;
            }
        }

        






        public void Order()
        {
            try
            {
                

                using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT 
                    o.id_order, 
                    STRING_AGG(oi.fk_article, ', ') as articles,
                    os.order_status,
                    o.date_order, 
                    o.date_delivery, 
                    pp.pickup_point,                                
                    u.user_name,
                    oi.quantity_order
                FROM public.""order"" o
                JOIN public.order_items oi ON oi.fk_order = o.id_order
                JOIN public.product p ON p.article = oi.fk_article 
                JOIN public.order_status os ON os.id_order_status = o.fk_status
                JOIN public.pickup_point pp ON pp.id_pickup = o.fk_pickup
                JOIN public.users u ON u.id_user = o.fk_user
                GROUP BY o.id_order, os.order_status, o.date_order, o.date_delivery, pp.pickup_point, u.user_name, oi.quantity_order
                ORDER BY o.id_order DESC";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql,connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            flowLayoutPanel1.Controls.Clear();
                            while (reader.Read())

                            {
                                OrderUC order = new OrderUC();
                                order.Role = this.ThisRole;
                                order.Id = reader.GetInt32(0);
                                order.Article = reader.GetString(1);
                                order.Status = reader.GetString(2);
                                order.OrderDate = reader.GetDateTime(3);
                                order.DeliveryDate = reader.GetDateTime(4);
                                order.Pickup = reader.GetString(5);
                                order.Name = reader.GetString(6);
                                order.Quantity = reader.GetInt32(7);
                                order.SetLabels();
                                flowLayoutPanel1.Controls.Add(order);
                                
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var form = new OrderAddForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Order();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
