using Abp.UI;
using System.Linq;
using Abp.AutoMapper;
using Castle.Core.Internal;
using System.Collections.Generic;
using AutoMapper;
using Cbd.Fgw.Core.IRepository;
using Cbd.Fgw.Application.System.User.Dto;

namespace Cbd.Fgw.Application.System.User {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserService : FgwAppServiceBase, IUserService {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository) {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public UserDto GetUser(int id) {
            var users = _userRepository.Get(id);

            return users.MapTo<UserDto>();
        }

        public List<UserDto> GetAllUsers() {
            var data = _userRepository.GetAll();

            return data.MapTo<List<UserDto>>();
        }

        public UserSearchOutput GetUsers(UserSearchInput input = null) {
            if (input == null) {
                input = new UserSearchInput();
            }

            Logger.Info(" 查询用户信息，查询内容： " + input);
            var inputUser = input.MapTo<Core.System.User>();
            var total = _userRepository.GetAllList().Count;
            var users = _userRepository.GetUsers(inputUser);
            if (users == null) {
                throw new UserFriendlyException("未查询到数据。");
            }

            var rows = users.MapTo<List<UserDto>>();
            rows = rows.Skip(input.Offset).Take(input.Limit).ToList();

            return new UserSearchOutput { Total = total, Rows = rows };
        }

        public void UpdateUser(UserUpdateInput input) {
            Logger.Info(" 更新用户信息，更新内容： " + input.UserName);
            var user = input.MapTo<Core.System.User>();
            _userRepository.Update(user);
        }

        public void CreateUser(UserCreateInput input) {
            Logger.Info(" 新建用户，新建内容： " + input);
            var user = input.MapTo<Core.System.User>();
            _userRepository.Insert(user);
        }

        public void Delete(int id) {
            _userRepository.Delete(id);
        }

        public void ChangeActive(UserChangeActiveInput input) {
            var user = _userRepository.Get(input.Id);
            user.IsActive = input.IsActive;
        }

        public void SetAuthorization(UserAuthorizationInput input) {
            var user = _userRepository.GetUserAndRoles().Single(r => r.Id == input.Id);
            user.Roles = new List<Core.System.Role>();
            input.Roles.ForEach(r => {
                user.Roles.Add(_roleRepository.Get(r.Id));
            });
        }
    }
}
