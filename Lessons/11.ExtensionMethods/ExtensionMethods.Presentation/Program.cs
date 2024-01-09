using System;

public static class StringExtensions
{
    public static int CountVowels(this string str)
    {
        int count = 0;
        foreach (char c in str.ToLower())
        {
            if ("aeiou".Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    public static bool IsPalindrome(this string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
    }

    public static string Truncate(this string str, int maxLength)
    {
        return str.Length <= maxLength ? str : str.Substring(0, maxLength);
    }
}

class Program
{
    static void Main()
    {
        string text = "Programming with extension methods is fun.";

        int vowelCount = text.CountVowels();
        Console.WriteLine($"Vowel Count: {vowelCount}");

        bool isPalindrome = text.IsPalindrome();
        Console.WriteLine($"Is Palindrome: {isPalindrome}");

        string truncatedText = text.Truncate(20);
        Console.WriteLine($"Truncated Text: {truncatedText}");
    }
}