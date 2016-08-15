using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cbd.Fgw.Core.System {
    public class Menu : Entity {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { set; get; }
        /// <summary>
        /// 菜单链接
        /// </summary>
        public string MenuUrl { set; get; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { set; get; }
        /// <summary>
        /// 是否为菜单组
        /// </summary>
        public bool IsMenuGroup { set; get; }
        /// <summary>
        /// 是否为根菜单
        /// </summary>
        public bool IsRoot { set; get; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public int? ParentMenuId { set; get; }
        /// <summary>
        /// 菜单描述
        /// </summary>
        public string Describe { set; get; }

        [ForeignKey("ParentMenuId")]
        public virtual Menu ParentMenu { set; get; }
        public virtual ICollection<Role> Roles { set; get; }
    }
}
