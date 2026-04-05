using Blazored.LocalStorage;
using Movvi.Web.Repository.Interface;
using System.Threading.Tasks;

namespace Movvi.Web.Repository
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
