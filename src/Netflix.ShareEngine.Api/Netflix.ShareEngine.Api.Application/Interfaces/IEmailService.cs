namespace Netflix.ShareEngine.Api.Application.Interfaces
{
    public interface IEmailService
    {
        void CreateEmailAccount(string email, string password); 
    }
}