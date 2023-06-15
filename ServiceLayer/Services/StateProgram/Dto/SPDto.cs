namespace ServiceLayer.Services;
public record SPDto(
    int id,
    int order_number,
    string? short_name,
    string? full_name,
    SDto? Status);
