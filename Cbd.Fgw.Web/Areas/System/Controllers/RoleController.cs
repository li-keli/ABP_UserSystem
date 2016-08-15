using Abp.UI;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Abp.Authorization;
using Cbd.Fgw.Web.Controllers;
using Cbd.Fgw.Application.System.Menu;
using Cbd.Fgw.Application.System.Role;
using Cbd.Fgw.Application.System.Role.Dto;
using Cbd.Fgw.Core.System;

namespace Cbd.Fgw.Web.Areas.System.Controllers {
    [AbpAuthorize("Administration")]
    public class RoleController : FgwControllerBase {
        private readonly IRoleService _roleService;
        private readonly IMenuService _menuService;

        public RoleController(IRoleService roleService, IMenuService menuService) {
            _roleService = roleService;
            _menuService = menuService;
        }

        public ActionResult Index(RoleDto input) {
            return View();
        }

        public ActionResult IndexList(RoleSearchDtoInput input) {
            var data = _roleService.GetAll(input);
            return Json(data);
        }

        public ActionResult Details(int? id) {
            if (!id.HasValue) {
                throw new Exception($"未查询到角色");
            }
            var input = new RoleDto { Id = id.Value };
            var data = _roleService.Get(input);
            return View(data);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleCreateInput input) {
            if (ModelState.IsValid) {
                _roleService.CreateRole(input);
                ViewBag.Success = "success";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (!id.HasValue) {
                throw new Exception($"未查询到角色");
            }
            var input = new RoleDto { Id = id.Value };
            var data = _roleService.Get(input);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleCreateInput input) {
            if (ModelState.IsValid) {
                _roleService.EditRole(input);
                ViewBag.Success = "success";
            }
            return View();
        }

        public ActionResult Delete(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException("未查询到角色");
            }
            _roleService.DeleteRole(id.Value);
            return Json("success");
        }

        public ActionResult Authorization(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException("未查询到角色");
            }
            var roleDto = _roleService.GetAndMenu(id.Value);
            var menus = _menuService.GetAll();

            return View(new RoleAuthorizationOutput { RoleDto = roleDto, MenuDtos = menus });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorization(int id, int[] menuids) {
            if (ModelState.IsValid) {
                var roleAuthorizationInput = new RoleAuthorizationInput {
                    Id = id,
                    Menus = new List<Menu>()
                };
                if (menuids != null) {
                    foreach (var menuid in menuids) {
                        roleAuthorizationInput.Menus.Add(new Menu { Id = menuid });
                    }
                }

                _roleService.SetAuthorization(roleAuthorizationInput);
                ViewBag.Success = "success";
            }
            var roleDto = _roleService.GetAndMenu(id);
            var menus = _menuService.GetAll();

            return View(new RoleAuthorizationOutput { RoleDto = roleDto, MenuDtos = menus });
        }
    }
}