using Abp.Application.Services;
using Cbd.Fgw.System.Dto;

namespace Cbd.Fgw.System {
    public interface IUserService : IApplicationService {
        UserSearchOutput GetUsers(UserSearchInput input);
        void UpdateUser(UserUpdateInput input);
        void CreateUser(UserCreateInput input);
    }
}
