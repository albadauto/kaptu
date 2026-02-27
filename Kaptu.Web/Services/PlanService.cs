using Blazored.LocalStorage;
using Kaptu.Web.Repository.Interface;
using System.Threading.Tasks;

namespace Kaptu.Web.Repository
{
    public class PlanService(ILocalStorageService localStorageService) : IPlanService
    {
        public ILocalStorageService _localStorageService { get; set; } = localStorageService;

        public async Task SetPlanLocalStorage(int idPlan)
        {
            await _localStorageService.SetItemAsync<int>("planId", idPlan);
        }
    }
}
