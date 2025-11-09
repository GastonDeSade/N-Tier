namespace N_Tier.BLL.Entities;

public class Product : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}