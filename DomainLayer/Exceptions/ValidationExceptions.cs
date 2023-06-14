namespace DomainLayer.Exceptions;
public class ValidationExceptions : Exception
{
    public ValidationExceptions(string message)
        : base(message)
    { }
}
