using DomainLayer.Entities.ENUM;

namespace ServiceLayer.Services;
public record SectorDto(
    int id,
    int sector_number,
    Status status,
    int order_number,
    string? short_name,
    string? full_name);
