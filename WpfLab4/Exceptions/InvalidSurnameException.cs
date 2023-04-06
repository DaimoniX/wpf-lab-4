using System;

namespace WpfLab2.Exceptions;

public class InvalidSurnameException : InvalidNameSurnameException
{
    public InvalidSurnameException() : base() {}
    public InvalidSurnameException(string message) : base(message) {}
    public InvalidSurnameException(string message, Exception inner) : base(message, inner) { }
}
