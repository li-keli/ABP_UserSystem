using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Cbd.Fgw.System {
    public class RoleAndMenu : Entity {
        [ForeignKey("RoleId")]
        public virtual Role Role { set; get; }
        [Display(Name = "角色编号")]
        public virtual int RoleId { set; get; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { set; get; }
        [Display(Name = "菜单编号")]
        public virtual int MenuId { set; get; }
    }
}
