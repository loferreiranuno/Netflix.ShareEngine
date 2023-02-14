using Netflix.ShareEngine.Api.Application.Interfaces;

namespace Netflix.ShareEngine.Api.Application.Services
{
    public class GeneratorService : IGeneratorService
    {
        const string USERNAME_SEED = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string PASSWORD_SEED = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";    

        public string GenerateUsername(int maxUsernameLength) => Generate(maxUsernameLength, USERNAME_SEED);
        public string GeneratePassword(int maxUsernameLength) => Generate(maxUsernameLength, PASSWORD_SEED);
        
        private string Generate(int maxUsernameLength, string seed)
        {            
            var random = new Random();
            var username = new string(
                Enumerable.Repeat(seed, maxUsernameLength)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
            return username;
        }
    }
}