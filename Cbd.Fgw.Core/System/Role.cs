using Abp.Domain.Entities;
using System.Collections.Generic;

namespace Cbd.Fgw.Core.System {
    public class Role : Entity {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { set; get; }
        /// <summary>
        /// 是否系统角色
        /// </summary>
        public bool IsSystem { set; get; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { set; get; }

        public virtual ICollection<User> Users { set; get; }
        public virtual ICollection<Menu> Menus { set; get; }
    }
}
