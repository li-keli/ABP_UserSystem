using System.Linq;
using Abp.UI;
using System.Web.Mvc;
using Abp.Authorization;
using Cbd.Fgw.Application.System.Department;
using Cbd.Fgw.Application.System.Department.Dto;
using Cbd.Fgw.Web.Controllers;

namespace Cbd.Fgw.Web.Areas.System.Controllers {

    [AbpAuthorize("Administration")]
    public class DepartmentController : FgwControllerBase {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult GetJsonByAsync(int? id) {
            var data = _departmentService.GetTreeAsync(id);
            return Json(data);
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult IndexList(DepartmentSearchInput input) {
            return Json(_departmentService.GetAll(input));
        }

        public ActionResult Details(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException("未查询到部门");
            }

            return View(_departmentService.Get(id.Value));
        }

        public ActionResult Create() {
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "Id", "DepartmentName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentCreateInput input) {
            if (ModelState.IsValid) {
                _departmentService.Create(input);
                ViewBag.Success = "success";
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll().Where(d => d.Id != input.Id), "Id", "DepartmentName");

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException($"未查询到部门");
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll().Where(d => d.Id != id.Value), "Id", "DepartmentName");

            return View(_departmentService.Get(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentCreateInput input) {
            if (ModelState.IsValid) {
                _departmentService.Edit(input);
                ViewBag.Success = "success";
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll().Where(d => d.Id != input.Id), "Id", "DepartmentName");

            return View(_departmentService.Get(input.Id));
        }

        public ActionResult Delete(int? id) {
            if (!id.HasValue) {
                throw new UserFriendlyException("未查询到部门");
            }
            _departmentService.Delete(id.Value);

            return Json("success");
        }
    }
}