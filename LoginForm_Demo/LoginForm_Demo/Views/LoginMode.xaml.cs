using LoginForm_Demo.Functions;
using System;
using System.Windows;

namespace LoginForm_Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginMode.xaml
    /// </summary>
    public partial class LoginMode : Window
    {
        public LoginMode()
        {
            InitializeComponent();
        }
        LoadData ld = new LoadData();
        bool IsLogined;

        private void Sign_mode_Click(object sender, RoutedEventArgs e)
        {
            ld.ReadData();

            if (String.IsNullOrWhiteSpace(Login_mode.Text) || String.IsNullOrWhiteSpace(password_mode.Password))
            {
                MessageBox.Show("Complete all fields");
                return;
            }
            string pass_hash = SHA512_Hashing.Convert_Hash(password_mode.ToString());
            for (int i = 0; i < ld.UserList.Count; i++)
            {
                if (string.Compare(Login_mode.Text, ld.UserList[i].Login, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(pass_hash, ld.UserList[i].Password, StringComparison.CurrentCulture) == 0)
                {
                    if (ld.UserList[i].IsAdmin == false)
                    {
                        MessageBox.Show("You do not have access");
                    }
                    else
                        if (ld.UserList[i].IsAdmin == true)
                        {
                        ChangeLogon clg = new ChangeLogon();
                        clg.Show();
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

        private void Exit_mode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
                mw.Show();
            Close();
        }
    }
}
