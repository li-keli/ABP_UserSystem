using System.Data.Entity.Migrations;

namespace Cbd.Fgw.Migrations {

    public partial class InitialCreate : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.Menus",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    MenuName = c.String(unicode: false),
                    ParentMenuId = c.String(unicode: false),
                    Url = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.RoleAndMenus",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    RoleId = c.Int(nullable: false),
                    MenuId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);

            CreateTable(
                "dbo.Roles",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    RoleName = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserAndRoles",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    RoleId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Users",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(unicode: false),
                    Pwd = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down() {
            DropForeignKey("dbo.UserAndRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAndRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleAndMenus", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleAndMenus", "MenuId", "dbo.Menus");
            DropIndex("dbo.UserAndRoles", new[] { "RoleId" });
            DropIndex("dbo.UserAndRoles", new[] { "UserId" });
            DropIndex("dbo.RoleAndMenus", new[] { "MenuId" });
            DropIndex("dbo.RoleAndMenus", new[] { "RoleId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserAndRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.RoleAndMenus");
            DropTable("dbo.Menus");
        }
    }
}
