using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplicationWithTest.Configuration;
using WebApplicationWithTest.Dtos;
using WebApplicationWithTest.Repositories;

namespace WebApplicationWithTest.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _jwtSettings = jwtSettings.Value;
        }

        public JWTTokens AuthenticateUserAsync(string username, string password)
        {
            var user = _userRepository.GetUserByUsernameAsync(username);

            var token = GenerateJwtToken(user.Id.ToString());
            return token;
        }

        private JWTTokens GenerateJwtToken(string userId)
        {
            var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var encryptionkey = Encoding.UTF8.GetBytes(_jwtSettings.EncryptionKey);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);


            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.ValidIssuer,
                Audience = _jwtSettings.ValidAudience,
                IssuedAt = DateTime.Now,
                //NotBefore = DateTime.Now.AddDays(Convert.ToDouble(iconfiguration["JWT:accessTokenExpiration"])),
                Expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.AccessTokenExpiration)),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                }),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            string encryptedJwt = tokenHandler.WriteToken(securityToken);

            string refreshToken = GenerateRefreshToken();

            return new JWTTokens() { AccessToken = encryptedJwt, RefreshToken = refreshToken, Expires = descriptor.Expires };
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
