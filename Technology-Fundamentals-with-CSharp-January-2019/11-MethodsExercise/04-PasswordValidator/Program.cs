using System;

namespace _04_PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] password = Console.ReadLine().ToCharArray();

            bool isValid1 = CheckLength(password);
            bool isValid2 = CheckForInvalidChars(password);
            bool isValid3 = CheckForDigits(password);

            if (isValid1 && isValid2 && isValid3)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool CheckLength(char[] password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
        }

        private static bool CheckForInvalidChars(char[] password)
        {
            int invalidChars = 0;

            foreach (var character in password)
            {
                if ((int)character < 48)
                {
                    invalidChars++;
                }
                if ((int)character > 57 && (int)character < 65)
                {
                    invalidChars++;
                }
                if ((int)character > 90 && (int)character < 97)
                {
                    invalidChars++;
                }
                if ((int)character > 122)
                {
                    invalidChars++;
                }
            }

            if (invalidChars > 0)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool CheckForDigits(char[] password)
        {
            int numOfDigits = 0;

            foreach (var character in password)
            {
                if ((int)character >= 48 && (int)character <= 57)
                {
                    numOfDigits++;
                }
            }

            if (numOfDigits >= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }
        }
    }
}
