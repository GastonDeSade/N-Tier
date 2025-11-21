using N_Tier.BLL.Entities;

namespace N_Tier.BLL.DTOs;

public class ProductPaginationUpDto
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public int TotalCount { get; set; }
    public Product[] data { get; set; }
}