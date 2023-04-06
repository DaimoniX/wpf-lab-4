using System;

namespace WpfLab2.Exceptions;

public class OldBirthDateException : InvalidBirthDateException
{
    public OldBirthDateException() : base() {}
    public OldBirthDateException(string message) : base(message) {}
    public OldBirthDateException(string message, Exception inner) : base(message, inner) { }
}
