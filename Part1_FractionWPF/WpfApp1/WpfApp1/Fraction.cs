using System;

namespace WpfApp1
{
    public class Fraction
    {
        private int _num;
        private int _denom;

        public int Numerator
        {
            get => _num;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Числитель >= 0");
                _num = value;
            }
        }

        public int Denominator
        {
            get => _denom;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Знаменатель > 0");
                _denom = value;
            }
        }

        public Fraction(int num, int denom)
        {
            Numerator = num;
            Denominator = denom;
        }

        public double ToPercentage()
        {
            return (Numerator / (double)Denominator) * 100;
        }

        public int DenominatorDigitSum()
        {
            int sum = 0;
            int temp = Denominator;

            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }

            return sum;
        }

        public bool IsProperFraction()
        {
            return Numerator < Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}