using AutoMapper;
using Kaptu.ApiService.Commands.Tenants.CreateTenant;
using Kaptu.ApiService.Commands.Users.AddUser;
using Kaptu.ApiService.Queries.User.GetUserByMail;
using Kaptu.DLL.DTO;
using Kaptu.DLL.Models;

namespace Kaptu.ApiService.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<User, AddUserCommand>();
            CreateMap<AddUserCommand, User>();
            CreateMap<CreateTenantCommand, Tenant>();
            CreateMap<Tenant, CreateTenantCommand>();
        }
    }
}
