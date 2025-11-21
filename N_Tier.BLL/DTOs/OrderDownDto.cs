namespace N_Tier.BLL.DTOs;

public class OrderDownDto
{
    public string idUser { get; set; }
    public List<OrderProductDownDto> OrderProducts { get; set; }
}