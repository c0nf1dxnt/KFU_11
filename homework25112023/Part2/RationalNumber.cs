using System;

namespace Part2
{
    [DeveloperInfo("Farkhat Kleverov", "11/30/2023")]
    public class RationalNumber
    {
        private int numerator;
        private int denominator;

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0!");
            }
            if (numerator == denominator)
            {
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public RationalNumber(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }
        public override string ToString()
        {
            return denominator == 1 ? $"{numerator}" : $"{numerator}/{denominator}";
        }
        public static bool operator ==(RationalNumber number1, RationalNumber number2)
        {
            return number1.numerator * number2.denominator == number2.numerator * number1.denominator;
        }
        public static bool operator !=(RationalNumber number1, RationalNumber number2)
        {
            return !(number1 == number2);
        }
        public static bool operator <(RationalNumber number1, RationalNumber number2)
        {
            return number1.numerator * number2.denominator < number2.numerator * number1.denominator;
        }
        public static bool operator >(RationalNumber number1, RationalNumber number2)
        {
            return number1.numerator * number2.denominator > number2.numerator * number1.denominator;
        }
        public static bool operator <=(RationalNumber number1, RationalNumber number2)
        {
            return number1.numerator * number2.denominator <= number2.numerator * number1.denominator;
        }
        public static bool operator >=(RationalNumber number1, RationalNumber number2)
        {
            return number1.numerator * number2.denominator >= number2.numerator * number1.denominator;
        }
        public static RationalNumber operator +(RationalNumber number1, RationalNumber number2)
        {
            return new RationalNumber(number1.numerator * number2.denominator + number2.numerator * number1.denominator, number1.denominator * number2.denominator);
        }
        public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
        {
            return new RationalNumber(number1.numerator * number2.denominator - number2.numerator * number1.denominator, number1.denominator * number2.denominator);
        }
        public static RationalNumber operator *(RationalNumber number1, RationalNumber number2)
        {
            return new RationalNumber(number1.numerator * number2.numerator, number1.denominator * number2.denominator);
        }
        public static RationalNumber operator /(RationalNumber number1, RationalNumber number2)
        {
            return new RationalNumber(number1.numerator * number2.denominator, number1.denominator * number2.numerator);
        }
        public static RationalNumber operator ++(RationalNumber number1)
        {
            return number1 + new RationalNumber(1);
        }
        public static RationalNumber operator --(RationalNumber number1)
        {
            return number1 - new RationalNumber(1);
        }
        public static explicit operator int(RationalNumber number1)
        {
            return number1.numerator / number1.denominator;
        }
        public static explicit operator float(RationalNumber number1)
        {
            return (float)number1.numerator / number1.denominator;
        }
        public static int operator %(RationalNumber number1, RationalNumber number2)
        {
            RationalNumber resultingNumber = number1 / number2;
            return (resultingNumber.numerator % resultingNumber.denominator);
        }
        public override bool Equals(object obj)
        {
            if (obj is RationalNumber number)
            {
                return this == number;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
