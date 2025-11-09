using Microsoft.AspNetCore.Identity;
namespace N_Tier.BLL.Entities;

public class User : IdentityUser
{
    public string? Initials {get; set;}
}