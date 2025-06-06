namespace BusModule.DTOs
{
    public class TokenResponseDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
    public class  RefreshTokenRequestDto
    {
        public int UserId { get; set; }
        public required string RefreshToken { get; set; } = string.Empty;
    }
}
