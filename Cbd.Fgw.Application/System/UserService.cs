using Abp.UI;
using Cbd.Fgw.IRepository;
using System.Collections.Generic;
using Abp.AutoMapper;
using Castle.Core.Internal;
using Cbd.Fgw.System.Dto;

namespace Cbd.Fgw.System {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserService : FgwAppServiceBase, IUserService {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public UserSearchOutput GetUsers(UserSearchInput input) {
            Logger.Info(" 查询用户信息，查询内容： " + input);
            var user = input.MapTo<User>();
            var data = _userRepository.GetAllUsers(user);
            if (data == null) {
                throw new UserFriendlyException("未查询到数据。");
            }

            return new UserSearchOutput {
                Users = data.MapTo<List<UserDto>>()
            };
        }

        public void UpdateUser(UserUpdateInput input) {
            Logger.Info(" 更新用户信息，更新内容： " + input);
            var user = _userRepository.Get(input.UserId);
            if (!input.UserName.IsNullOrEmpty()) {
                user.UserName = "老李";
            }

            //不需要调用Update方法
            //因为应用服务层的方法默认开启了工作单元模式（Unit of Work）
            //框架会在工作单元完成时自动保存对实体的所有更改，除非有异常抛出。有异常时会自动回滚，因为工作单元默认开启数据库事务。
        }

        public void CreateUser(UserCreateInput input) {
            Logger.Info(" 新建用户，新建内容： " + input);
            var user = input.MapTo<User>();
            _userRepository.Insert(user);
        }
    }
}
