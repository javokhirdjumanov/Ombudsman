using DomainLayer.Entities.ENUM;

namespace ServiceLayer.Services;
public record SPDto(
    int id,
    int orderNumber,
    string? shortName,
    string? fullName,
    StateDto? state);
