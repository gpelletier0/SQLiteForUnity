using System.Text;
using Random = System.Random;

/// <summary>
/// Random Name Generator Class
/// </summary>
public static class RandomName
{
    private static readonly Random rnd = new Random();
    private static readonly string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };
    private static readonly string[] vowels = { "a", "e", "i", "o", "u", "y" };

    /// <summary>
    /// Generates a random name form constants and vowels
    /// </summary>
    /// <param name="len">lenght of name</param>
    /// <returns>Random name of given lenght</returns>
    public static string Generate(int len)
    {
        StringBuilder Name = new StringBuilder();

        Name.Append(GetConstantAndVowel());
        Name[0] = char.ToUpper(Name[0]);

        for (int b = Name.Length; b < len; b += 2)
        {
            Name.Append(GetConstantAndVowel());
        }

        return Name.ToString();
    }

    /// <summary>
    /// Generates a random constant and vowel
    /// </summary>
    /// <returns>Random constant and vowel</returns>
    private static string GetConstantAndVowel() => consonants[rnd.Next(consonants.Length)] + vowels[rnd.Next(vowels.Length)];
}