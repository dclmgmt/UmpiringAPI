using System.Threading.Tasks;
using UmpiringApi.Models;

namespace UmpiringApi.Repositories
{
    public interface IAuthRepository
    {
        Task<TblUser> Register(TblUser user, string password);
        Task<TblUser> Login(string username, string password);
        Task<bool> UserExists(string username); 
    }
}