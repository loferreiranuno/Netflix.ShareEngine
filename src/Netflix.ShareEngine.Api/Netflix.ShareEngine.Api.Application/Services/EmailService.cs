using System;
using System.IO;
using Netflix.ShareEngine.Api.Application.Interfaces;
using Renci.SshNet;

namespace Netflix.ShareEngine.Api.Application.Services
{

    public class EmailService : IEmailService
    {
        private readonly string _serverAddress;
        private readonly string _username;
        private readonly string _password;

        public EmailService(string serverAddress, string username, string password)
        {
            _serverAddress = serverAddress;
            _username = username;
            _password = password;
        }

        public void CreateEmailAccount(string email, string password)
        {
            using (var client = new SshClient(_serverAddress, _username, _password))
            {
                client.Connect();

                var emailFile = "/etc/postfix/virtual_users";
                var emailLine = email + " " + email;

                client.RunCommand("echo " + emailLine + " >> " + emailFile);

                var passwordFile = "/etc/postfix/virtual_passwords";
                var encryptedPassword = EncryptPassword(password);
                var passwordLine = email + ":{PLAIN}" + encryptedPassword;

                client.RunCommand("echo " + passwordLine + " >> " + passwordFile);

                client.RunCommand("postmap hash:" + emailFile);
                client.RunCommand("postmap hash:" + passwordFile);

                client.RunCommand("systemctl restart postfix");

                client.Disconnect();
            }
        }

        private string EncryptPassword(string password)
        {
            // Implement encryption logic here
            return password;
        }
    }
}
