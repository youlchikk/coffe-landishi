using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace coffe_app
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidPhone(string phone)
        {
            string pattern = @"^\+?[1-9]\d{6,14}$";
            return Regex.IsMatch(phone, pattern);
        }
    }

}
