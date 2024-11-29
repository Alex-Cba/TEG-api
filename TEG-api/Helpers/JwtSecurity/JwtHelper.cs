using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace TEG_api.Helpers.JwtSecurity
{
    public class JwtHelper
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiryInMinutes;
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _secretKey = configuration["JwtOptions:SecretKey"];
            _issuer = configuration["JwtOptions:Issuer"];
            _audience = configuration["JwtOptions:Audience"];
            _expiryInMinutes = int.Parse(configuration["JwtOptions:ExpiryInMinutes"]);
        }

        public string GenerateToken(string userId, string userName, string role)
        {
            var privateKey = Convert.FromBase64String(_secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKey, out _);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            };
            var identity = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _issuer,
                Audience = _audience,
                Expires = DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
