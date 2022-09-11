using Identity.Dtos;

namespace Identity.Repositories
{
    public interface IAuthenticationService
    {
        Task<JWTTokenResult> GetJWTToken(UserLoginModel user);
    }
}
