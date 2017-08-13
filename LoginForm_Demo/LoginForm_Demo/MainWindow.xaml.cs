using System.Windows;
using System;
using LoginForm_Demo.Functions;
using LoginForm_Demo.Views;
using System.Windows.Input;
using LoginForm_Demo.Models;

namespace LoginForm_Demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User usr = new User();
        LoadData ld = new LoadData();
        private bool IsLogined;
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(Keyboard.KeyDownEvent, (KeyEventHandler) Login_mode);
        }

        private void Login_mode(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && (Keyboard.Modifiers == ModifierKeys.Control))
            {
                LoginMode lm = new LoginMode();
                lm.Owner = this;
                lm.ShowDialog();
                Close();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            UserReg ureg = new UserReg();
            ureg.Show();
            Close();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            ld.ReadData();

            if (String.IsNullOrWhiteSpace(Login.Text) || String.IsNullOrWhiteSpace(password.Password))
            {
                MessageBox.Show("Complete all fields");
                return;
            }
            string pass_hash = SHA512_Hashing.Convert_Hash(password.ToString());
            for (int i = 0; i < ld.UserList.Count; i++)
            {
                if (string.Compare(Login.Text, ld.UserList[i].Login, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(pass_hash, ld.UserList[i].Password, StringComparison.CurrentCulture) == 0)
                { 
                    if (ld.UserList[i].IsAdmin == false)
                    {
                        UserPage upg = new UserPage();
                        upg.Show();
                        Close();
                        IsLogined = true;
                        break;
                    }
                    else 
                        if(ld.UserList[i].IsAdmin == true)
                        {
                            AdminPage apg = new AdminPage();
                        apg.Show();
                        Close();
                        IsLogined = true;
                        break;
                        }
                }
            }
            if (!IsLogined)
            {
                MessageBox.Show("Невірний логін або пароль");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
