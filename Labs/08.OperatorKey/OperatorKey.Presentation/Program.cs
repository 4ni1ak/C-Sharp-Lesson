namespace OperatorKey.Presentation
{
    class Rational
    {
        private int numerator { get; set; }=0;
        private int denominator { get; set; }=1;
        public Rational(int numerator, int denominator)
        {
         
            this.numerator = numerator;
            this.denominator = denominator;
            SmplifyFanction();
        }

        private void SmplifyFanction()
        {
            int smaller= Math.Min(Math.Abs(numerator), Math.Abs(denominator));
            for (int i = smaller; i > 1; i--)
            {
                if (numerator % i is  0 || denominator % i is 0) continue;
                numerator/=i; denominator/=i;
                break;

            }
        }

        public static Rational operator +(Rational a, Rational b)
        {
            int resultNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            int resultDenominator = a.denominator * b.denominator;
            Rational result = new(resultNumerator, resultDenominator);
            result.SmplifyFanction();
            return result;
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int resultNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            int resultDenominator = a.denominator * b.denominator;
            Rational result = new (resultNumerator, resultDenominator);
            result.SmplifyFanction();
            return result;
        }

        public static Rational operator *(Rational a, Rational b)
        {
            int resultNumerator = a.numerator * b.numerator;
            int resultDenominator = a.denominator * b.denominator;
            Rational result = new (resultNumerator, resultDenominator);
            result.SmplifyFanction();
            return result;
        }

        public static Rational operator /(Rational a, Rational b)
        {
            int resultNumerator = a.numerator * b.denominator;
            int resultDenominator = a.denominator * b.numerator;

            if (resultDenominator == 0)
            {
                throw new InvalidOperationException("Cannot divide by zero.");
            }

            Rational result = new(resultNumerator, resultDenominator);
            result.SmplifyFanction();
            return result;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public string ToFloatingPointString(int precision)
        {
            double result = (double)numerator / denominator;
            return result.ToString($"F{precision}");
        }
    }

    class Program
    {
        static void Main()
        {
            Rational fraction1 = new(2, 4);
            Rational fraction2 = new(3, 6);

            Console.WriteLine($"Fraction 1: {fraction1}");
            Console.WriteLine($"Fraction 2: {fraction2}");

            Rational sum = fraction1 + fraction2;
            Console.WriteLine($"Sum: {sum}");

            Rational difference = fraction1 - fraction2;
            Console.WriteLine($"Difference: {difference}");

            Rational product = fraction1 * fraction2;
            Console.WriteLine($"Product: {product}");

            Rational quotient = fraction1 / fraction2;
            Console.WriteLine($"Quotient: {quotient}");

            Console.WriteLine($"Floating-point format of Fraction 1: {fraction1.ToFloatingPointString(2)}");
            Console.WriteLine($"Floating-point format of Fraction 2: {fraction2.ToFloatingPointString(2)}");
        }
    }
}
