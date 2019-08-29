using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UmpiringApi.Models;

namespace UmpiringApi.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly SQL2008_739130_dallascrickContext _context;
        
        public AuthRepository(SQL2008_739130_dallascrickContext context)
        {
            _context = context;
        }

        public async Task<TblUser> Login(string email, string password)
        {
            var user = await _context.TblUser.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.Password, user.Salt))
                return null;

            return user; // auth successful
        }

        public async Task<TblUser> Register(TblUser user, string password)
        {
            byte[] passwordHash, salt;
            CreatePasswordHash(password, out passwordHash, out salt);
            user.Password = passwordHash;
            user.Salt = salt;

            await _context.TblUser.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string Username)
        {
            if (await _context.TblUser.AnyAsync(x => x.Email == Username))
                return true;
            return false;
        }
    }
}