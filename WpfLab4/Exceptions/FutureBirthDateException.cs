using System;

namespace WpfLab2.Exceptions;

public class FutureBirthDateException : InvalidBirthDateException
{
    public FutureBirthDateException() : base() {}
    public FutureBirthDateException(string message) : base(message) {}
    public FutureBirthDateException(string message, Exception inner) : base(message, inner) { }
}
