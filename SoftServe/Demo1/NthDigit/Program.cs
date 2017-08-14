using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int digit = IntPow(n, n);

            if (digit.ToString().Length < n)
            {
                Console.WriteLine("*");
            }
            else
            {
                int digitLength = digit.ToString().Length;
                Console.WriteLine(digit.ToString()[digitLength - n]);
            }
        }
        public static int IntPow(int number, int power)
        {
            int result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}
