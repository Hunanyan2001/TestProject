using TestProject.Interfaces;

namespace TestProject.Configuration
{
    public class JwtOptions : IJwtOptions
    {
        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpiryInMinutes { get; set; }
    }
}
