using LoginForm_Demo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm_Demo.Functions
{
    class LoadData
    {
        private List<User> userList = new List<User>();

        internal List<User> UserList { get => userList; set => userList = value; }

        public  void Write_Data()
        {
            if (!Directory.Exists(@"files"))
            {
                Directory.CreateDirectory(@"files");
            }

            BinaryWriter writer = new BinaryWriter(File.Open(@"files\Users.dlv", FileMode.Append),Encoding.BigEndianUnicode);
            foreach (User login in UserList)
            {
                writer.Write(login.FirstName);
                writer.Write(login.LastName);
                writer.Write(login.Phone);
                writer.Write(login.SecretNumber);
                writer.Write(login.Login);
                writer.Write(login.Password);
                writer.Write(login.IsAdmin);
            }
        }
        public void ReadData()
        { 
            try
            {

                BinaryReader reader = new BinaryReader(File.Open(@"files\Users.dlv", FileMode.Open), Encoding.BigEndianUnicode);
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    UserList.Add(new User(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadBoolean()));
                }
                reader.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Виникла помилка з файлом бази данних профілів");
            }
        }   
    }
}
