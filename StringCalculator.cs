using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDD
{
    public  class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers)) return 0;

            bool IsAllDigits(string s)
            {
                foreach (char c in s)
                {
                    if (!char.IsDigit(c) && c!=' '&& c!= ',')
                        return false;
                }
                return true;
            }

            if (IsAllDigits(numbers))
            {
                int sum = numbers.Split(new char[] { ',', ' ' })
                       .Select(n => int.Parse(n))
                       .Sum();
                return sum;
            }
            else
            {
                throw new ArgumentException(nameof(numbers));
            }
        }
    }
}
