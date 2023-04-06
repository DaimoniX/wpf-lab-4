using System;

namespace WpfLab2.Exceptions;

public class EmailFormatException : FormatException
{
    public EmailFormatException() : base() {}
    public EmailFormatException(string message) : base(message) {}
    public EmailFormatException(string message, Exception inner) : base(message, inner) { }
}
