namespace  Netflix.ShareEngine.Domain.Entities.Exceptions;
public class ConfigurationException : Exception
{
    public ConfigurationException(string message) : base(message)
    {
    }
}