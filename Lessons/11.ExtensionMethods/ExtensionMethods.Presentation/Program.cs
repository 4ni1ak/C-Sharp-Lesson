using System.Text;

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

    public static string Reverse(this string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static string ConvertToTitleCase(this string str)
    {
        string[] words = str.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(words[i]))
            {
                char[] letters = words[i].ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                words[i] = new string(letters);
            }
        }
        return string.Join(' ', words);
    }

    public static string EncodeBase64(this string str)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(bytes);
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

        string reversedText = text.Reverse();
        Console.WriteLine($"Reversed Text: {reversedText}");

        string titleCaseText = text.ConvertToTitleCase();
        Console.WriteLine($"Title Case Text: {titleCaseText}");

        string base64EncodedText = text.EncodeBase64();
        Console.WriteLine($"Base64 Encoded Text: {base64EncodedText}");
    }
}
