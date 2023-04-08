using System;
using System.Linq;
using System.Text;

namespace WpfLab2.Main;

public class PersonGenerator
{
    private readonly Random _random;
    private static readonly string[] Consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
    private static readonly string[] Vowels = { "a", "e", "i", "o", "u", "ae", "y" };

    public PersonGenerator()
    {
        _random = new Random(DateTime.Now.Second);
    }
    
    private string RandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
    }

    private string RandomName(int lenght)
    {
        var name = new StringBuilder();
        name.Append(Consonants[_random.Next(Consonants.Length)].ToUpper());
        name.Append(Vowels[_random.Next(Vowels.Length)]);
        var b = 2;
        while (b < lenght)
        {
            name.Append(Consonants[_random.Next(Consonants.Length)]).Append( Vowels[_random.Next(Vowels.Length)]);
            b += 2;
        }
        return name.ToString();
    }

    public Person GeneratePerson()
    {
        var randDate = new DateTime(1960, 1, 1);
        randDate = randDate.AddDays(_random.Next((DateTime.Today - randDate).Days));
        var name = RandomName(_random.Next(5, 14));
        var surname = RandomName(_random.Next(5, 14));
        var email = $"{RandomString(_random.Next(7, 18))}@mail.com";
        return new Person(name, surname, email, randDate);
    }
}