using System;
using System.Text.RegularExpressions;
using WpfLab2.Exceptions;
using WpfLab2.Zodiac;

namespace WpfLab2.Main;

public class Person
{
    public string Name { get; }
    public string Surname { get; }
    public string Email { get; }
    public DateTime BirthDate { get; }
    
    public bool IsAdult { get; }
    public SunSign SunSign { get; }
    public ChineseSign ChineseSign { get; }
    public bool IsBirthday { get; }

    private static void CheckEmailFormat(string email)
    {
        if (!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            throw new EmailFormatException("Invalid email format");
    }

    private static void CheckBirthDate(DateTime birthdate)
    {
        var today = DateTime.Today;
        if (today <= birthdate)
            throw new FutureBirthDateException("Future date specified as birthdate");
        if ((today - birthdate).Days / 365 >= 135)
            throw new OldBirthDateException("Age cannot be more than 135");
    }

    private static void CheckNameSurname(string name, string surname)
    {
        if (!Regex.IsMatch(name, "^(?:[a-zA-Z]+)$"))
            throw new InvalidNameException("Invalid name");
        if (!Regex.IsMatch(surname, "^(?:[a-zA-Z]+)$"))
            throw new InvalidSurnameException("Invalid surname");
    }

    public Person(string name, string surname, string email, DateTime birthDate)
    {
        CheckNameSurname(name, surname);
        Name = name;
        Surname = surname;
        CheckEmailFormat(email);
        Email = email;
        CheckBirthDate(birthDate);
        BirthDate = birthDate;
        var today = DateTime.Today;
        IsAdult = (today - birthDate).Days / 365 > 17;
        IsBirthday = today.Day == birthDate.Day && today.Month == birthDate.Month;
        SunSign = ZodiacSign.GetSunSign(birthDate);
        ChineseSign = ZodiacSign.GetChineseSign(birthDate);
    }
    
    public Person(string name, string surname, DateTime birthDate) : this(name, surname, string.Empty, birthDate) {}

    public Person(string name, string surname, string email) : this(name, surname, email, DateTime.Today) {}

    public override string ToString()
    {
        return $"{Name} {Surname}{Environment.NewLine}{ChineseSign}{Environment.NewLine}{SunSign}";
    }
}