namespace MicroservicesPractice.Web.Services.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetTokenAsync();
    }
}
