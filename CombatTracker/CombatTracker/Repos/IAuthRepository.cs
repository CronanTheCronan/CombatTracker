using CombatTracker.Models;
using System.Threading.Tasks;

namespace CombatTracker.Repos
{
    public interface IAuthRepository
    {
        Task<Users> Register(Users user, string password);
        Task<Users> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
