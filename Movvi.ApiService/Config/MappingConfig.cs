using AutoMapper;
using Movvi.ApiService.Commands.Tenants.CreateTenant;
using Movvi.ApiService.Commands.Users.AddUser;
using Movvi.ApiService.Queries.User.GetUserByMail;
using Movvi.DLL.DTO;
using Movvi.DLL.Models;

namespace Movvi.ApiService.Config
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
