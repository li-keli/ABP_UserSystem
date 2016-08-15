using Abp.UI;
using System.Web.Mvc;
using Abp.Authorization;
using Cbd.Fgw.Web.Controllers;
using Cbd.Fgw.Application.System.Menu;
using Cbd.Fgw.Application.System.Menu.Dto;

namespace Cbd.Fgw.Web.Areas.System.Controllers {
    [AbpAuthorize("Administration")]
    public class MenuController : FgwControllerBase {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService) {
            _menuService = menuService;
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult IndexList(MenuSearchInputDto input) {
            var list = _menuService.Get(input);
            return Json(list);
        }

        public ActionResult Details(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException("未找到该菜单！");
            }

            return View(_menuService.Get(id.Value));
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuCreateInputDto input) {
            if (ModelState.IsValid) {
                _menuService.Create(input);
                ViewBag.Success = "success";
            }

            return View();
        }

        public ActionResult Edit(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException("未找到该菜单！");
            }

            return View(_menuService.Get(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuEditInputDto input) {
            if (ModelState.IsValid) {
                _menuService.Edit(input);
                ViewBag.Success = "success";
            }

            return View();
        }

        public ActionResult Delete(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException("未找到菜单");
            }
            _menuService.Delete(id.Value);
            return Json("success");
        }
    }
}