using System;
using System.Collections.Generic;
using System.Text;

namespace RationalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber a = new RationalNumber(1, 2);
            RationalNumber b = new RationalNumber(3, 4);

            RationalNumber sum = a + b;
            RationalNumber difference = a - b;
            RationalNumber product = a * b;
            RationalNumber quotient = a / b;

            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Разность: {difference}");
            Console.WriteLine($"Произведение: {product}");
            Console.WriteLine($"Частное: {quotient}");

            Console.WriteLine($"a == b? {a == b}");
            Console.WriteLine($"a != b? {a != b}");
            Console.WriteLine($"a < b? {a < b}");
            Console.WriteLine($"a <= b? {a <= b}");
            Console.WriteLine($"a > b? {a > b}");
            Console.WriteLine($"a >= b? {a >= b}");

            Console.ReadLine();
        }
    }
}
