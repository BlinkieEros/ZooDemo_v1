using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using ZooDemoExam.Properties;

namespace ZooDemoExam
{
    public partial class AuthForm : Form
    {

        public string Name { get;  set; }
        public string Role { get;  set; }
        public AuthForm()
        {
            InitializeComponent();
        }

        public void UserAuth()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Resources.connectionString))
            {
                connection.Open();
                string query = "select user_role, user_name, user_login, user_password from users join user_role ur on id_user_role = fk_user_role where user_login = @login and user_password = @password";

                using (NpgsqlCommand command = new NpgsqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("login",txtLogin.Text);
                    command.Parameters.AddWithValue("password",txtPassword.Text);

                    using (NpgsqlDataReader reader = command.ExecuteReader())

                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                Role = reader.GetString(0);
                                Name = reader.GetString(1);

                                MessageBox.Show("Успешная авторизация!", "Успешный вход.", MessageBoxButtons.OK);
                                this.Hide();
                                var form = new MainForm(this);
                                form.ShowDialog();

                                
                            }

                            
                            
                        }
                        if (Role == null)
                        {
                            MessageBox.Show("Неверный логин или пароль", "Внимание", MessageBoxButtons.OK);
                            return;
                        }
                    }

                }
                
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "")
            {
             
                MessageBox.Show("Введите логин", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Введите пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserAuth();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Name = "Гость";
            Role = "Гость";
            MainForm form = new MainForm(this);
            
            form.Show();
        }
    }
    
}
