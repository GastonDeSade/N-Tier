using N_Tier.BLL.Entities;
using N_Tier.DAL.Interfaces;

namespace N_Tier.DAL.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserByUserId(string userId)
    {
        return await _context.Users.FindAsync(userId);
    }

}


