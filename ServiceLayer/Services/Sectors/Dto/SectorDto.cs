using DomainLayer.Entities.ENUM;

namespace ServiceLayer.Services;
public record SectorDto(
    int id,
    int sectorNumber,
    StateDto state,
    int orderNumber,
    string? shortName,
    string? fullName);
