namespace UserTestingApp.Common.Exceptions;

public class NoRigthAnswerException : Exception
{
    public NoRigthAnswerException(string? message)
        : base(message) { }
}
