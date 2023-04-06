using System;

namespace WpfLab2.Exceptions;

public class InvalidNameSurnameException : FormatException
{
    public InvalidNameSurnameException() : base() {}
    public InvalidNameSurnameException(string message) : base(message) {}
    public InvalidNameSurnameException(string message, Exception inner) : base(message, inner) { }
}