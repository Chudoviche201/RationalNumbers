using System;

namespace RationalNumbers
{
    public class RationalNumber
    {
        private int numerator;   // числитель
        private int denominator; // знаменатель

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");

            this.numerator = numerator;
            this.denominator = denominator;
            Simplify(); // Приведение дроби к несократимому виду
        }

        // Метод для приведения дроби к несократимому виду
        private void Simplify()
        {
            int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            // Обработка отрицательных чисел
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        // Метод для нахождения наибольшего общего делителя двух чисел
        private int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }

        // Перегрузка оператора сложения (+)
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            int numerator = a.numerator * b.denominator + b.numerator * a.denominator;
            int denominator = a.denominator * b.denominator;
            return new RationalNumber(numerator, denominator);
        }

        // Перегрузка оператора вычитания (-)
        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            int numerator = a.numerator * b.denominator - b.numerator * a.denominator;
            int denominator = a.denominator * b.denominator;
            return new RationalNumber(numerator, denominator);
        }

        // Перегрузка оператора умножения (*)
        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            int numerator = a.numerator * b.numerator;
            int denominator = a.denominator * b.denominator;
            return new RationalNumber(numerator, denominator);
        }

        // Перегрузка оператора деления (/)
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            int numerator = a.numerator * b.denominator;
            int denominator = a.denominator * b.numerator;
            return new RationalNumber(numerator, denominator);
        }

        // Перегрузка оператора сравнения равенства (==)
        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return a.Equals(b);
        }

        // Перегрузка оператора сравнения неравенства (!=)
        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !a.Equals(b);
        }

        // Перегрузка оператора сравнения меньше (<)
        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        // Перегрузка оператора сравнения меньше или равно (<=)
        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        // Перегрузка оператора сравнения больше (>)
        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        // Перегрузка оператора сравнения больше или равно (>=)
        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        // Переопределение метода Equals для сравнения рациональных чисел
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            RationalNumber other = (RationalNumber)obj;
            return numerator == other.numerator && denominator == other.denominator;
        }

        // Переопределение метода GetHashCode
        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode();
        }

        // Переопределение метода CompareTo для сравнения рациональных чисел
        public int CompareTo(RationalNumber other)
        {
            long left = numerator * (long)other.denominator;
            long right = other.numerator * (long)denominator;

            if (left < right)
                return -1;
            else if (left > right)
                return 1;
            else
                return 0;
        }

        // Переопределение метода ToString для вывода рационального числа в виде строки
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        // Метод для получения информации об экземпляре класса
        public void GetInfo()
        {
            Console.WriteLine($"Рациональное число: {ToString()}");
        }
    }
}