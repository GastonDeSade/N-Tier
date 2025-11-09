using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;
using N_Tier.DAL.Interfaces;

namespace N_Tier.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<User?> GetUserByUserId(string userId)
    {
        return await _userRepository.GetUserByUserId(userId);
    }
}