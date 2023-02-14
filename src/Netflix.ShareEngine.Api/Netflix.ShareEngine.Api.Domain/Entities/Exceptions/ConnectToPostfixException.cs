namespace Netflix.ShareEngine.Domain.Entities.Exceptions;

public class ConnectToPostfixException : Exception {
     
    public ConnectToPostfixException(string message, Exception inner) : base(message, inner) 
    {
        
    }
}