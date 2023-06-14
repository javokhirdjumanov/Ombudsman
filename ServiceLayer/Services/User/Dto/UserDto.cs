namespace ServiceLayer.Services;
public record UserDto(
    int id,
    string FIO,
    string PhoneNumber,
    string Email,
    string role);
