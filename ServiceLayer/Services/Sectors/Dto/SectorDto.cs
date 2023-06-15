namespace ServiceLayer.Services;
public record SectorDto(
    int id,
    int sector_number,
    SDto status,
    int order_number,
    string? short_name,
    string? full_name);
