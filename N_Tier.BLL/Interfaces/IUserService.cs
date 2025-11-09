using N_Tier.BLL.Entities;

namespace N_Tier.BLL.Manager.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetUserByUserId(string userId);
}