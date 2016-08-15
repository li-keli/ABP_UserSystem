using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Cbd.Fgw.Core.System;
using Cbd.Fgw.EntityFramework.EntityFramework;

namespace Cbd.Fgw.EntityFramework.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<FgwDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Fgw";
        }

        protected override void Seed(FgwDbContext context) {
            //初始化种子数据
            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "朝阳区",
                    Describe = "朝阳区，本系统根组织",
                    IsSystem = true
                },
                new Department
                {
                    DepartmentName = "投资科",
                    Describe = "负责投资管控的业务部门。",
                    DepartmentId = 1
                },
                new Department
                {
                    DepartmentName = "招商科",
                    Describe = "招商引资的业务部门。",
                    DepartmentId = 1
                },
                new Department
                {
                    DepartmentName = "CBD通信",
                    Describe = "正式投入使用前，系统的测试部门。",
                    DepartmentId = 1
                }
            };
            departments.ForEach(d => context.Departments.Add(d));

            var menuGroups = new List<Menu>
            {
                new Menu {MenuName = "项目管理", IsMenuGroup=true, Icon = "fa fa-database"},
                new Menu {MenuName = "统计查询", IsMenuGroup=true, Icon = "fa fa-bar-chart"},
                new Menu {MenuName = "系统管理", IsMenuGroup=true, Icon = "fa fa-cog"}
            };
            menuGroups.ForEach(m => { context.Menus.Add(m); });

            var childrenMenus = new List<Menu>
            {

                new Menu {MenuName = "新建项目", MenuUrl = "", ParentMenuId = 1},
                new Menu {MenuName = "项目审批", MenuUrl = "", ParentMenuId = 1},
                new Menu {MenuName = "项目建设", MenuUrl = "", ParentMenuId = 1},
                new Menu {MenuName = "竣工项目", MenuUrl = "", ParentMenuId = 1},

                new Menu {MenuName = "项目统计", MenuUrl = "", ParentMenuId = 2},

                new Menu {MenuName = "用户管理", MenuUrl = "system/User", ParentMenuId = 3},
                new Menu {MenuName = "角色管理", MenuUrl = "system/Role", ParentMenuId = 3},
                new Menu {MenuName = "部门管理", MenuUrl = "system/Department", ParentMenuId = 3},
                new Menu {MenuName = "菜单管理", MenuUrl = "system/Menu", ParentMenuId = 3},
                new Menu {MenuName = "日志管理", MenuUrl = "system/SysLog", ParentMenuId = 3}
            };
            childrenMenus.ForEach(m => context.Menus.Add(m));

            var role = new Role {
                RoleName = "超级管理员",
                IsSystem = true,
                Describe = "超级管理员拥有系统最高权限，并被系统保留，无法删除和编辑。",
                Menus = new List<Menu>()
            };
            context.Roles.Add(role);
            var adminRole = new List<Menu>();
            adminRole.AddRange(menuGroups);
            adminRole.AddRange(childrenMenus);
            role.Menus = adminRole;

            var user = new User {
                UserName = "admin",
                RealName = "管理员",
                Pwd = "123",
                DepartmentId = 2,
                IsActive = true,
                IsSystem = true,
                Roles = new List<Role>()
            };
            context.Users.Add(user);

            user.Roles = new List<Role> { role };
            context.SaveChangesAsync();
        }
    }
}
