using System;
using System.Threading.Tasks;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace vaulttest.Services
{
    public class VaultService
    {
        private readonly IVaultClient _vaultClient;

        public VaultService()
        {
            var authMethod = new TokenAuthMethodInfo("root");
            var vaultClientSettings = new VaultClientSettings("http://localhost:8200", authMethod);
            _vaultClient = new VaultClient(vaultClientSettings);
        }

        public async Task<Secret<VaultSharp.V1.SecretsEngines.UsernamePasswordCredentials>> GetDatabaseCredentialsAsync()
        {
            try
            {
                var secret = await _vaultClient.V1.Secrets.Database.GetCredentialsAsync("my-role");
                return secret; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving credentials: {ex.Message}");
                throw; 
            }
        }

    }

    public class UsernamePasswordCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
