using System.Windows;
using LoginForm_Demo;
using System;
using System.Windows.Input;
using LoginForm_Demo.Models;
using LoginForm_Demo.Functions;
using System.Linq;

namespace LoginForm_Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для UserReg.xaml
    /// </summary>
    public partial class UserReg : Window
    {
        User usr = new User();
        LoadData ld = new LoadData();
        ValidateInput vi = new ValidateInput();

        internal ValidateInput Vi { get => vi; set => vi = value; }

        public UserReg()
        {
            InitializeComponent();
            AddHandler(Keyboard.KeyDownEvent, (KeyEventHandler)Admin_check);
        }

        private void Admin_check(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && (Keyboard.Modifiers == ModifierKeys.Control))
            {
                is_admin.Visibility = Visibility.Visible;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            bool IsError = false;
            if(!Vi.CheckNullOrEmpty(fname.GetLineText(0), lname.GetLineText(0), num.GetLineText(0), secret_num.GetLineText(0), login_reg.GetLineText(0), passw1.ToString()))
            {
                MessageBox.Show("Fields must not be empty");
                return;
            }

            if(!Vi.CheckLetter(fname.GetLineText(0), lname.GetLineText(0)))
            {
                MessageBox.Show("First- and Last- name must be letters");
                IsError = true;
            }
            
            if(!Vi.CheckLoginAndPassword(login_reg.GetLineText(0),passw1.ToString()))
            {
                MessageBox.Show("Login and password must be letters or digits");
                IsError = true;
            }
                
            if (Vi.CheckLetter(secret_num.GetLineText(0)))
                {
                    MessageBox.Show("Secret number must be digit");
                    IsError = true;
            }

            if (num.MaxLength > 12)
            {
                MessageBox.Show("Phone number is incorrect");
            }
                if (passw1.Password != passw2.Password)
            {
                MessageBox.Show("Wrong submit password");
                passw1.Clear();
                passw2.Clear();
                IsError = true;
            }
            

            if (IsError == true)
            {
                return;
            }

            else
            {
                bool IsAdmin = false;
                if (is_admin.IsChecked == true)
                    IsAdmin = true;

                string pass_valid = SHA512_Hashing.Convert_Hash(passw1.ToString());
                User tmp = new User(fname.Text, lname.Text, num.Text, secret_num.Text, login_reg.Text, pass_valid, IsAdmin);
                if (ld.UserList.Contains(tmp))
                {
                    MessageBox.Show(string.Format("Profile  " + login_reg.Text + " already exist" +
                                                  "\nCreate profile with a different name"));
                    login_reg.Clear();
                }
                else
                {
                    ld.UserList.Add(tmp);
                    ld.Write_Data();
                    MessageBox.Show("Profile successfully created");
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    Close();
                }
            }


        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }

}
