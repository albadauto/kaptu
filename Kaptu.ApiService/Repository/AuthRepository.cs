using Kaptu.ApiService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kaptu.ApiService.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public readonly SqlServerContext _sqlServerContext;
        public AuthRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }
        public async Task AddOtp(string email, string code)
        {
            await _sqlServerContext.Otp.AddAsync(new DLL.Models.Otp
            {
                Email = email,
                Code = code,
                IsActive = true,
                ExpirationTime = DateTime.UtcNow.AddMinutes(10)
            });
            await _sqlServerContext.SaveChangesAsync();

        }

        public async Task<bool> VerifyOtp(string email, string code)
        {
           var otp = await _sqlServerContext.Otp.Where(x => x.Email == email && x.Code == code &&
           x.IsActive && x.ExpirationTime > DateTime.UtcNow).FirstOrDefaultAsync();

            if(otp != null)
            {
                otp.IsActive = false;
                _sqlServerContext.Otp.Update(otp);
                await _sqlServerContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
