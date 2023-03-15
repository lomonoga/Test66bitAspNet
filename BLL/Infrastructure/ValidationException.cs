namespace Test66bit.BLL.Infrastructure;

public class ValidationException : Exception
{ 
    private string Property { get; }
    
    public ValidationException(string message, string prop) : base(message)
    {
        Property = prop;
    }
}