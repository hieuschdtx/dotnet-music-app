using Microsoft.Extensions.Options;
using Music_app.Infrastructure.Configurations;

namespace Music_app.Api.Configurations
{
    public class AuthOptionConfiguration : IConfigureOptions<AuthOption>
    {
        private const string sectionName = "Jwt";
        private readonly IConfiguration _configuration;
        public AuthOptionConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(AuthOption options)
        {
            _configuration.GetSection(sectionName).Bind(options);
        }
    }
}