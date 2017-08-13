using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace LoginForm_Demo.Models
{
    class User
    {
        private string firstName;
        private string lastName;
        private string phone;
        private string secretNumber;
        private string login;
        private string password;
        private bool isAdmin;

        public User()
        {
        }

        public User(string firstName, string lastName, string phone, string secretNumber, string login, string password, bool isAdmin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.secretNumber = secretNumber;
            this.login = login;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Phone { get => phone; set => phone = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string SecretNumber { get => secretNumber; set => secretNumber = value; }
    }
}
   
