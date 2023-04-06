using System;

namespace WpfLab2.Exceptions;

public class InvalidBirthDateException : ArgumentException
{
    public InvalidBirthDateException() : base() {}
    public InvalidBirthDateException(string message) : base(message) {}
    public InvalidBirthDateException(string message, Exception inner) : base(message, inner) { }
}
