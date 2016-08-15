using Abp.Domain.Entities;
using System.Collections.Generic;

namespace Cbd.Fgw.Core.System {
    public class User : Entity {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { set; get; }
        public string Pwd { set; get; }

        public int? DepartmentId { set; get; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsActive { set; get; }
        /// <summary>
        /// 是否系统帐号，系统帐号禁止删除
        /// </summary>
        public bool IsSystem { set; get; }

        public virtual ICollection<Role> Roles { set; get; }
        public virtual Department Department { set; get; }
    }
}
