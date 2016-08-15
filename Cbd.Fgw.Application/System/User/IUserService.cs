using Abp.Application.Services;
using System.Collections.Generic;
using Cbd.Fgw.Application.System.User.Dto;

namespace Cbd.Fgw.Application.System.User {
    public interface IUserService : IApplicationService {
        UserDto GetUser(int id);
        List<UserDto> GetAllUsers();
        UserSearchOutput GetUsers(UserSearchInput input = null);
        void UpdateUser(UserUpdateInput input);
        void CreateUser(UserCreateInput input);
        void Delete(int id);
        /// <summary>
        /// 更新用户状态
        /// </summary>
        void ChangeActive(UserChangeActiveInput input);
        /// <summary>
        /// 用户授权
        /// </summary>
        void SetAuthorization(UserAuthorizationInput input);
    }
}
