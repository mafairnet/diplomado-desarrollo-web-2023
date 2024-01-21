using Microsoft.Extensions.Configuration;

namespace ControlEscolarApi.Authorization
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        public bool IsValid(string apiKeyValue) {
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var apiKey = config.GetSection("ApiKey").Value;

            if (apiKey == apiKeyValue) {
                return true;
            }
            return false;
        }
    }

    public interface IApiKeyValidator { 
        bool IsValid(string apiKeyValue);
    }
}
