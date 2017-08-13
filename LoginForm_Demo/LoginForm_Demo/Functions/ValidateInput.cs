using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm_Demo.Functions
{
    class ValidateInput
    {
        public bool CheckLetter(params string[] par)
        {
            foreach (string str in par)
                if (!str.All(c => Char.IsLetter(c)))
                {
                    return false;
                }

            return true;
        }

        public bool CheckLoginAndPassword(params string[] par)
        {
            foreach (string str in par)
                if (!str.All(c => Char.IsLetter(c) || !Char.IsLetter(c)))
                {
                    return false;
                }

            return true;
        }

        public bool CheckNullOrEmpty(params string[] par)
        {
            foreach (string str in par)
            {
                if (String.IsNullOrEmpty(str))
                    return false;
            }

            return true;
        }
    }
}
