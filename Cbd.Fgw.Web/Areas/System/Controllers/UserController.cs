using System;
using AutoMapper;
using System.Web.Mvc;
using Abp.AutoMapper;
using Cbd.Fgw.Core.System;
using Cbd.Fgw.Web.Controllers;
using System.Collections.Generic;
using Abp.Authorization;
using Cbd.Fgw.Application.System.Role;
using Cbd.Fgw.Application.System.User;
using Cbd.Fgw.Application.System.User.Dto;
using Cbd.Fgw.Application.System.Role.Dto;
using Cbd.Fgw.Application.System.Department;

namespace Cbd.Fgw.Web.Areas.System.Controllers {
    [AbpAuthorize("Administration")]
    public class UserController : FgwControllerBase {

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IDepartmentService _departmentService;

        public UserController(IUserService userService, IDepartmentService departmentService, IRoleService roleService) {
            _userService = userService;
            _departmentService = departmentService;
            _roleService = roleService;
        }

        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult IndexList(UserSearchInput input) {
            return Json(_userService.GetUsers(input));
        }

        public ActionResult Details(int? id) {
            if (!id.HasValue) {
                return new HttpStatusCodeResult(404, "没有找到此用户");
            }
            var user = _userService.GetUser(id.Value);
            if (user == null) {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult Create() {
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "Id", "DepartmentName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateInput userCreateInput) {
            if (ModelState.IsValid) {
                _userService.CreateUser(userCreateInput);
                ViewBag.Success = string.Empty;
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "Id", "DepartmentName");

            return View();
        }

        public ActionResult Edit(int? id) {
            if (!id.HasValue) {
                return new HttpStatusCodeResult(404, "没有找到此用户");
            }
            var user = _userService.GetUser(id.Value);
            if (user == null) {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "Id", "DepartmentName");
            Mapper.CreateMap<UserDto, UserCreateInput>();
            return View(user.MapTo<UserCreateInput>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserUpdateInput userUpdateInput) {
            if (ModelState.IsValid) {
                _userService.UpdateUser(userUpdateInput);
                ViewBag.Success = string.Empty;
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "Id", "DepartmentName");

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id) {
            if (!id.HasValue) {
                return new HttpStatusCodeResult(404, "没有找到此用户");
            }
            _userService.Delete(id.Value);

            return Json("success");
        }

        [HttpPost]
        public ActionResult ChangeActive(UserChangeActiveInput input) {
            if (ModelState.IsValid) {
                _userService.ChangeActive(input);
            }
            return Json("success");
        }

        public ActionResult Authorization(int? id) {
            if (!id.HasValue) {
                return new HttpStatusCodeResult(404, "没有找到此用户");
            }

            return View(_roleService.GetAll(new RoleDto()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorization(int id, string[] roles) {
            if (ModelState.IsValid) {
                var input = new UserAuthorizationInput {
                    Id = id,
                    Roles = new List<Role>()
                };
                foreach (var role in roles) {
                    input.Roles.Add(new Role { Id = Convert.ToInt32(role) });
                }
                _userService.SetAuthorization(input);
                ViewBag.Success = "success";
            }

            return View(_roleService.GetAll(new RoleDto()));
        }

    }
}