using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Cbd.Fgw.System.Dto {
    public class UserOutput : IOutputDto {
        public List<UserDto> Users { set; get; }
    }

    public class UserSearchOutput : IOutputDto {
        public List<UserDto> Users { set; get; }
    }
}
