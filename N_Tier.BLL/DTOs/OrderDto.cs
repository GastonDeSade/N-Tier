using N_Tier.BLL.Entities;

namespace N_Tier.BLL.DTOs;

public class OrderDto
{
    public string idUser { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}