namespace N_Tier.BLL.Entities;

public class Product : Base
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public float Price { get; set; }
    public string? Image { get; set; }
    public string? Image2 { get; set; }
    public string? Image3 { get; set; }
    public string? Image4 { get; set; }
    public List<OrderProduct>? OrderProducts { get; set; }
}