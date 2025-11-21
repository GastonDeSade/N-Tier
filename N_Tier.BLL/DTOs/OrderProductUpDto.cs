namespace N_Tier.BLL.DTOs;

public class OrderProductUpDto
{
    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}