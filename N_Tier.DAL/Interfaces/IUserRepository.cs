using N_Tier.BLL.Entities;

namespace N_Tier.DAL.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByUserId(string userId);
}