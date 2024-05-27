using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlowerClient
{
    internal class CheckingInput // проверка пароля и емэйла
    {
        public static bool IsStringInputValid(string input)
        {
            // Проверяем, что вводимые данные являются строкой
            return input is string;
        }

        public static bool IsValidEmail(string email)
        {
            // Шаблон регулярного выражения для проверки email адреса
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Проверка соответствия шаблону
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsStrongPassword(string password)
        {
            // Проверка длины пароля
            if (password.Length < 8)
            {
                return false;
            }

            // Проверка наличия символов разного регистра
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                return false;
            }

            // Проверка наличия цифр
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // Проверка наличия специальных символов
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return false;
            }

            return true;
        }
    }
}
