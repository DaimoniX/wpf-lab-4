using System;

namespace WpfLab2.Input;

public static class DateUtils
{
    public static bool IsBirthdayToday(this DateTime date)
    {
        var now = DateTime.Today;
        return now.Month == date.Month && now.Day == date.Day;
    }
}