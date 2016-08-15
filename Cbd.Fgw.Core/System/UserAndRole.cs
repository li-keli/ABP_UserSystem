using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Cbd.Fgw.System {
    public class UserAndRole : Entity {
        [ForeignKey("UserId")]
        public virtual User User { set; get; }
        [Display(Name = "用户编号")]
        public virtual int UserId { set; get; }

        [ForeignKey("RoleId")]
        public virtual Role Role { set; get; }
        [Display(Name = "角色编号")]
        public virtual int RoleId { set; get; }
    }
}
