using SSO.Core;

namespace SSO.Infrastructure.Configurations
{
    public class InfrastructureConfiguration : SSOConfiguration
    {
        public string DatabaseConnectionString { get; set; }
    }
}
