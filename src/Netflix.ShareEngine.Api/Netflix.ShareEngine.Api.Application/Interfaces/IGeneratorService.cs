namespace Netflix.ShareEngine.Api.Application.Interfaces
{
    public interface IGeneratorService 
    {
        string GenerateUsername(int maxUsernameLength);
        string GeneratePassword(int maxUsernameLength);
    }
}