namespace Movvi.Web.Services.Interface
{
    public interface IStripeService
    {
        public Task<string> CreateCheckoutSession(int userId);
    }
}
