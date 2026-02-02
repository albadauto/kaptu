using Blazored.LocalStorage;
using Kaptu.Web.Repository.Interface;
using System.Threading.Tasks;

namespace Kaptu.Web.Repository
{
    public class PlanService : IPlanService
    {
        public ILocalStorageService _localStorageService { get; set; }
        public PlanService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public async Task SetPlanLocalStorage(int idPlan)
        {
            await _localStorageService.SetItemAsync<int>("planId", idPlan);
        }
    }
}
