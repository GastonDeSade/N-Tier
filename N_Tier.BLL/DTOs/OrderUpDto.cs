using N_Tier.BLL.Entities;

namespace N_Tier.BLL.DTOs;

public class OrderUpDto
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public List<OrderProductDownDto> OrderProducts { get; set; }

}