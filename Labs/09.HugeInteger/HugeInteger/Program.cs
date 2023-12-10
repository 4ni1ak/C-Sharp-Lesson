using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class HugeInteger
{
    private int[] digits;
    public bool IsNegative { get; private set; } = false;
    public HugeInteger()
    {
        digits = new int[41];
    }

    
    public void Input(string number)
    {
        if (number.Length <= 40)
        {
            char[] charArray = number.ToCharArray();
            Array.Reverse(charArray);

            for (int i = 0; i < charArray.Length; i++)
            {
                digits[i] = int.Parse(charArray[i].ToString());
            }
        }
        else
        {
            throw new ArgumentException("Invalid input or number exceeds 40 digits.");
        }
    }

    public override string ToString()
    {
        string result = "";
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            result += digits[i].ToString();
        }

        if (IsNegative) result = "-" + result;
        string trimmedNumber = TrimLeadingZeros(result);
        return trimmedNumber.TrimStart('0');
    }
    public static string TrimLeadingZeros(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        int startIndex = 0;
        bool isNegative = input[0] == '-';

        if (isNegative || input[0] == '+')
        {
            startIndex = 1;
        }

        int nonZeroIndex = startIndex;
        while (nonZeroIndex < input.Length && input[nonZeroIndex] == '0')
        {
            nonZeroIndex++;
        }

        if (nonZeroIndex == input.Length)
        {
            return "0";
        }

        string trimmed = isNegative ? "-" : "";
        trimmed += input.Substring(nonZeroIndex);

        return trimmed;
    }

public static HugeInteger operator +(HugeInteger num1, HugeInteger num2)
    {
        HugeInteger result = new HugeInteger();

        int carry = 0;
        for (int i = 0; i < num1.digits.Length; i++)
        {
            int sum = num1.digits[i] + num2.digits[i] + carry;
            result.digits[i] = sum % 10;
            carry = sum / 10;
        }

        if (carry > 0)
        {
            throw new ArgumentException("Overflow: Sum exceeds 40 digits.");
        }

        return result;
    }

    public static HugeInteger operator -(HugeInteger num1, HugeInteger num2)
    {
        HugeInteger result = new HugeInteger();  
        int borrow = 0;

        if (num1.IsLessThan(num2))
        {
            result = num2 - num1;  
            result.IsNegative = true;
            return result;
        }

        for (int i = 0; i < num1.digits.Length; i++)
        {
            int diff = num1.digits[i] - borrow;
            if (i < num2.digits.Length)
            {
                diff -= num2.digits[i];
            }

            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }
            result.digits[i] = diff;
        }

        if (borrow == 1)
        {
            result.IsNegative = true;
        }

        return result;
    }


    public static bool operator ==(HugeInteger num1, HugeInteger num2)
    {
        return num1.IsEqualTo(num2);
    }

    public static bool operator !=(HugeInteger num1, HugeInteger num2)
    {
        return !num1.IsEqualTo(num2);
    }

    public static bool operator >(HugeInteger num1, HugeInteger num2)
    {
        return num1.IsGreaterThan(num2);
    }

    public static bool operator <(HugeInteger num1, HugeInteger num2)
    {
        return num1.IsLessThan(num2);
    }

    public static bool operator >=(HugeInteger num1, HugeInteger num2) => num1.IsGreaterThanOrEqualTo(num2);

    public static bool operator <=(HugeInteger num1, HugeInteger num2) => num1.IsLessThanOrEqualTo(num2);

    private bool IsEqualTo(HugeInteger other)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] != other.digits[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool IsNotEqualTo(HugeInteger other) => !IsEqualTo(other);

    private bool IsGreaterThan(HugeInteger other)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] > other.digits[i])
            {
                return true;
            }
            else if (digits[i] < other.digits[i])
            {
                return false;
            }
        }
        return false; //  If Equal
    }

    private bool IsLessThan(HugeInteger other) => !IsGreaterThan(other) && !IsEqualTo(other);

    private bool IsGreaterThanOrEqualTo(HugeInteger other) => IsGreaterThan(other) || IsEqualTo(other);

    private bool IsLessThanOrEqualTo(HugeInteger other)=>!IsGreaterThan(other);
  
}

class HugeIntegerBigInteger
{
    private BigInteger value;

    public void Input(string number)
    {
        if (BigInteger.TryParse(number, out BigInteger result))
        {
            value = result;
        }
        else
        {
            throw new ArgumentException("Invalid input.");
        }
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public static HugeIntegerBigInteger operator +(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        HugeIntegerBigInteger result = new HugeIntegerBigInteger
        {
            value = num1.value + num2.value
        };
        return result;
    }

    public static HugeIntegerBigInteger operator -(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        HugeIntegerBigInteger result = new HugeIntegerBigInteger
        {
            value = num1.value - num2.value
        };
        return result;
    }

    public static bool operator ==(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        return num1.value == num2.value;
    }

    public static bool operator !=(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        return num1.value != num2.value;
    }

    public static bool operator >(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        return num1.value > num2.value;
    }

    public static bool operator <(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        return num1.value < num2.value;
    }

    public static bool operator >=(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        return num1.value >= num2.value;
    }

    public static bool operator <=(HugeIntegerBigInteger num1, HugeIntegerBigInteger num2)
    {
        return num1.value <= num2.value;
    }
}

static class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Huge Integer App");
        Console.Write("Do you want to automatic  or manual check? If you want to use manual check,\nPlease write 'M' (default is automatic check)\n==>");
        char? userInput = Console.ReadKey().KeyChar;
        Console.WriteLine("\n");

        if (!userInput.HasValue || char.ToLower(userInput.Value) is not 'm')
        {
            Console.WriteLine("Automatic check started...");
            Automatic();
        }
        else
        {
            Manual();
        }


        Console.ForegroundColor = ConsoleColor.DarkBlue;//:)
        Console.WriteLine("Thank you for using me :)\nSee you later\n");
        Console.WriteLine("Anıl Akpınar");
        Console.WriteLine("220201013");
        Console.ResetColor();
    }

    static void Manual()
    {
        Console.WriteLine("Enter the first number (20-40 digits): ");
        string manualNum1 = Console.ReadLine();

        Console.WriteLine("Enter the second number (20-40 digits): ");
        string manualNum2 = Console.ReadLine();

        if (manualNum1.IsValidNumber() && manualNum2.IsValidNumber())
        {
            ProcessNumbers(manualNum1, manualNum2,GenerateRandom20to40DigitNumber(),GenerateRandom20to40DigitNumber());
        }
        else
        {
            Console.WriteLine("Invalid input. Numbers must be 20-40 digits long.\n.......\nAutomatically generating random numbers...");
            Automatic();

        }
    }

    static void Automatic()
    {
        string randomNum1 = GenerateRandom20to40DigitNumber();
        string randomNum2 = GenerateRandom20to40DigitNumber();

        string randomBigNum1 = GenerateRandom20to40DigitNumber();
        string randomBigNum2 = GenerateRandom20to40DigitNumber();

        ProcessNumbers(randomNum1, randomNum2, randomBigNum2,randomBigNum1);
    }

    static void ProcessNumbers(string num1, string num2,string bigNum1,string bigNum2)
    {
        HugeInteger hugeNum1 = new HugeInteger();
        hugeNum1.Input(num1);

        HugeInteger hugeNum2 = new HugeInteger();
        hugeNum2.Input(num2);

        Console.WriteLine($"Num1 (HugeInteger): {num1.ToString()}\n");
        Console.WriteLine($"Num2 (HugeInteger): {num2.ToString()}\n");

        HugeInteger sum = hugeNum1 + hugeNum2;
        Console.WriteLine($"Sum Array (HugeInteger): {sum.ToString()} \n");

        HugeInteger diff = hugeNum1 - hugeNum2;
        Console.WriteLine($"Difference Array (HugeInteger):{(diff.IsNegative?"-":"+") } {diff.ToString()} \n");

        Console.WriteLine($"IsEqualTo Array (HugeInteger): {hugeNum1 == hugeNum2}\n");
        Console.WriteLine($"IsNotEqualTo Array (HugeInteger): {hugeNum1 != hugeNum2} \n");
        Console.WriteLine($"IsGreaterThan Array (HugeInteger): {hugeNum1 > hugeNum2} \n");
        Console.WriteLine($"IsLessThan Array (HugeInteger): {hugeNum1 < hugeNum2}  \n");
        Console.WriteLine($"IsGreaterThanOrEqualTo Array (HugeInteger): {hugeNum1 >= hugeNum2}  \n");
        Console.WriteLine($"IsLessThanOrEqualTo Array (HugeInteger): {hugeNum1 <= hugeNum2}  \n");

        HugeIntegerBigInteger bigIntNum1 = new HugeIntegerBigInteger();
        bigIntNum1.Input(bigNum1);

        HugeIntegerBigInteger bigIntNum2 = new HugeIntegerBigInteger();
        bigIntNum2.Input(bigNum2);

        Console.WriteLine($"Num1 (HugeIntegerBigInteger): {bigNum1}  \n");
        Console.WriteLine($"Num2 (HugeIntegerBigInteger): {bigNum2}  \n");

        HugeIntegerBigInteger sumBigInt = bigIntNum1 + bigIntNum2;
        Console.WriteLine($"Sum BigInt (HugeIntegerBigInteger): {sumBigInt}  \n");

        HugeIntegerBigInteger diffBigInt = bigIntNum1 - bigIntNum2;
        Console.WriteLine($"Difference BigInt (HugeIntegerBigInteger): {diffBigInt}  \n");

        Console.WriteLine($"IsEqualTo BigInt (HugeIntegerBigInteger): {bigIntNum1 == bigIntNum2}  \n");
        Console.WriteLine($"IsNotEqualTo BigInt (HugeIntegerBigInteger): {bigIntNum1 != bigIntNum2}  \n");
        Console.WriteLine($"IsGreaterThan BigInt (HugeIntegerBigInteger): {bigIntNum1 > bigIntNum2}  \n");
        Console.WriteLine($"IsLessThan BigInt (HugeIntegerBigInteger): {bigIntNum1 < bigIntNum2}   \n");
        Console.WriteLine($"IsGreaterThanOrEqualTo BigInt (HugeIntegerBigInteger): {bigIntNum1 >= bigIntNum2}   \n");
        Console.WriteLine($"IsLessThanOrEqualTo BigInt (HugeIntegerBigInteger): {bigIntNum1 <= bigIntNum2}   \n");

    }

    static string GenerateRandom20to40DigitNumber()
    {
        Random random = new Random();
        int length = random.Next(20, 41);

        string number = "";

        for (int i = 0; i < length; i++)
        {
            number += random.Next(10); //:)
        }

        return number;
    }
    static bool IsValidNumber(this string number) => !string.IsNullOrEmpty(number) && number.Length >= 20 && number.Length <= 40;
}
