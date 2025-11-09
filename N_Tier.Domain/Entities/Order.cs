namespace N_Tier.BLL.Entities;

public class Order : Base
{
    public List<OrderProduct> OrderProducts { get; set; }
    public float TotalOrder { get; set; }
    public User User { get; set; }
}