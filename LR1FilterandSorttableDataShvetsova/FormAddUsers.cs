using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR1FilterandSorttableDataShvetsova.DBContext; 

namespace LR1FilterandSorttableDataShvetsova
{
    public partial class FormAddUsers : Form
    {
        public FormAddUsers()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void FormAddUsers_Load(object sender, EventArgs e)
        {
            BindingSourceRole.DataSource = model.Roles.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$",
RegexOptions.IgnoreCase);
            if (!reg.IsMatch(emailTextBox.Text))
            {
                MessageBox.Show("Почта не соответствует требованиям!");
                return;
            }
            if (!passwordTextBox.Text.Equals(passwordTextBox2.Text))
            {
                MessageBox.Show("Пароли не одинаковы!");
                return;
            }
            if (String.IsNullOrWhiteSpace(loginTextBox.Text) ||
            String.IsNullOrWhiteSpace(passwordTextBox.Text) ||
            String.IsNullOrWhiteSpace(first_NameTextBox.Text) ||
            String.IsNullOrWhiteSpace(second_NameTextBox.Text) ||
            !PhonemaskedTextBox.MaskCompleted)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            Users users = new Users();
            users.ID = 0;
            users.Login = loginTextBox.Text;
            users.Password = passwordTextBox.Text;
            users.Email = emailTextBox.Text;
            users.Phone = PhonemaskedTextBox.Text;
            users.First_Name = first_NameTextBox.Text;
            users.Second_Name = second_NameTextBox.Text;
            users.RoleID = (int)roleIDComboBox.SelectedValue;
            users.Gender = radioButtonMen.Checked ? "Мужской" : "Женский";

            try
            {
                //сохранение данных в БД
                model.Users.Add(users);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Данные добавлены!");
            Close();

        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
