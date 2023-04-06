using System;

namespace WpfLab2.Zodiac;

public static class ZodiacSign
{
    public static SunSign GetSunSign(DateTime birthDate)
    {
        var month = birthDate.Month;
        var day = birthDate.Day;

        if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            return SunSign.Aquarius;
        if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
            return SunSign.Pisces;
        if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            return SunSign.Aries;
        if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            return SunSign.Taurus;
        if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            return SunSign.Gemini;
        if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            return SunSign.Cancer;
        if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            return SunSign.Leo;
        if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            return SunSign.Virgo;
        if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            return SunSign.Libra;
        if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            return SunSign.Scorpio;
        if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            return SunSign.Sagittarius;
        return SunSign.Capricorn;
    }

    public static ChineseSign GetChineseSign(DateTime birthDate)
    {
        return (ChineseSign)(birthDate.Year % 12);
    }
    
    public static ChineseSign GetChineseSign(this ChineseSign s, DateTime birthDate)
    {
        return (ChineseSign)(birthDate.Year % 12);
    }
}