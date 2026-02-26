namespace Kaptu.ApiService.Repository.Interfaces
{
    public interface IAuthRepository
    {
        public Task AddOtp(string email, string code);
        public Task<bool> VerifyOtp(string email, string code);
    }
}
