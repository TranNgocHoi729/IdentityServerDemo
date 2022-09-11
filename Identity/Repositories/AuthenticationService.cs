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

        private List<string> ListPermissionCode(User user)
        {
            var _permissions = new List<string>();
            var _listRole = _context.UserRoles.Where(a => a.UserId.Equals(user.Id)).Select(a => a.RoleId);
            var _result = _context.RolePermissions.Where(a => _listRole.Contains(a.RoleId)).Select(a => a.PermissionId).ToList();
            var ListPermissionCode = _context.Permissions.Where(a => _result.Contains(a.Id)).Select(a => a.PermissionCode).Distinct().ToList();
            return ListPermissionCode;
        }

        private List<Claim> CreateClaimIdentity(User _User, List<string> PermissionCode)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("ID", _User.Id.ToString()),
                new Claim("Username", _User.UserName)
            };

            foreach (var item in PermissionCode)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            return claims;
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
                var _listPermission = ListPermissionCode(_User);
                var _listClaims = CreateClaimIdentity(_User, _listPermission);
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(),
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
