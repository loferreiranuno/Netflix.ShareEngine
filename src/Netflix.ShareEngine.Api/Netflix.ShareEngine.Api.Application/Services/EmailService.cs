using Netflix.ShareEngine.Api.Application.Interfaces;
using Netflix.ShareEngine.Domain.Entities.Exceptions;
using Renci.SshNet;

namespace Netflix.ShareEngine.Api.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _host;
        private readonly string _userName;
        private readonly string _password;

        public EmailService(string host, string userName, string password)
        {
            _host = host;
            _userName = userName;
            _password = password;
        }

        public void CreateEmailAccount(string email, string password)
        { 
            using var client = new SftpClient(_host, _userName, _password);
            client.Connect();
            client.Disconnect();
        } 

        public bool CanConnect()
        {
            try 
            {
                using var client = new SftpClient(_host, _userName, _password);

                client.Connect();

                if(client.IsConnected)
                {
                    return true;                 
                }
            }
            catch(Exception ex)
            {
                throw new ConnectToPostfixException($"Host: {_host} UserName:{_userName} Password:{_password}", ex);
            }

            return false;
        }
    }
}