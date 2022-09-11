using DataAccess.Data;
using DataAccess.Entities;
using Identity.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Repositories
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _configuration;

        public AuthenticationService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private User GetUserByUsernameAndPassword(UserLoginModel user)
        {
            var _user = _context.Users.FirstOrDefault(a => a.Password.Equals(user.Password) && a.UserName.Equals(user.Username));
            return _user;
        }

        public async Task<JWTTokenResult> GetJWTToken(UserLoginModel user)
        {
            try
            {
                var _User = GetUserByUsernameAndPassword(user);
                if (_User is null)
                {
                    return new JWTTokenResult
                    {
                        IsSuccess = false,
                        RefreshToken = "",
                        Token = ""
                    };
                }
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("ID", _User.Id.ToString()),
                        new Claim("Username", _User.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256),
                    Audience = _configuration["Jwt:Audience"],
                    Issuer = _configuration["Jwt:Issuer"]
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                //string resultJWT = "Bearer " + jwtTokenHandler.WriteToken(token);
                string resultJWT = jwtTokenHandler.WriteToken(token);
                return new JWTTokenResult
                {
                    IsSuccess = true,
                    RefreshToken = "",
                    Token = resultJWT
                };
            }
            catch (Exception e)
            {
                return new JWTTokenResult
                {
                    IsSuccess = false,
                    RefreshToken = "",
                    Token = ""
                };
            }
        }
    }
}
