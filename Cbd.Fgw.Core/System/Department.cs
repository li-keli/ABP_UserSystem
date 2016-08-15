using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Cbd.Fgw.Core.System {
    public class Department : Entity {
        public string DepartmentName { set; get; }
        public string Describe { set; get; }
        public bool IsSystem { set; get; }
        public virtual int? DepartmentId { set; get; }
        public virtual Department ParentDepartment { set; get; }
        public virtual ICollection<User> Users { set; get; }
    }
}
