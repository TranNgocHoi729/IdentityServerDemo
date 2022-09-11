namespace Identity.Dtos
{
    public class JWTTokenResult
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool IsSuccess { get; set; }
    }
}
