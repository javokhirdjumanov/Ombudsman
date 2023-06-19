namespace ServiceLayer.Services;
public class BaseEnumDto
{
    public int Id { get; set; }
    public int orderNumber { get; set; }
    public string? shortName { get; set; }
    public string? fullName { get; set; }
}
