using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes
{
    public static class TextVerification
    {
        public static bool VerifyName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(input, "Input is null or empty. Please try again.");
            }
            if (input.Length > 50)
            {
                throw new ArgumentException(input, "Input is too long (maximum length of 50)");
            }
            if (input.Length < 3)
            {
                throw new ArgumentException(input, "Input is too short (minimum length of 3)");
            }
            return true;
        }
    }
}