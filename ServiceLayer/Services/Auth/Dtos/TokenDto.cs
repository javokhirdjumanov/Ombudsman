namespace ServiceLayer.Services;
public record TokenDto(string accessToken, string? refreshToken, DateTime expiredDate);
