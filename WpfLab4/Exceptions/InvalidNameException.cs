using System;

namespace WpfLab2.Exceptions;

public class InvalidNameException : InvalidNameSurnameException
{
    public InvalidNameException() : base() {}
    public InvalidNameException(string message) : base(message) {}
    public InvalidNameException(string message, Exception inner) : base(message, inner) { }
}
