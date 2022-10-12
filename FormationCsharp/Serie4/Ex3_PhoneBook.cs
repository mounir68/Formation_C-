using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class PhoneBook
    {
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                return false;
            }
            if (phoneNumber[0] != 0)
            {
                return false;
            }
            if (phoneNumber[1] == 0)
            {
                return false;
            }
            return true;
        }

        public bool ContainsPhoneContact(string phoneNumber)
        {
            
            return false;
        }

        public void PhoneContact(string phoneNumber)
        {
            //TODO
        }

        public bool AddPhoneNumber(string phoneNumber, string name)
        {
            //TODO
            return false;
        }

        public bool DeletePhoneNumber(string phoneNumber)
        {
            //TODO
            return false;
        }

        public void DisplayPhoneBook()
        {
            //TODO
        }
    }
}
