using System.Web.Mvc;
using HRManager.Models.BindingModels.Project;
using HRManager.Models.ViewModels;
using HRManager.Models.ViewModels.Project;
using HRManager.Services;

namespace HRManager.App.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectService service;
        public ProjectController()
        {
            this.service = new ProjectService();
        }

        [HttpGet]
        public ActionResult AllProjects()
        {
            var projectsVm = this.service.GetAllProjectVms();
            return this.View(projectsVm);
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            EditProjectVm vm = this.service.GetEditProjectVm(id);
            return this.View(vm);
        }

        [HttpPost]
        public ActionResult EditProject(EditProjectBm bm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditProject(bm);
                return RedirectToAction("AllProjects");
            }
            return RedirectToAction("EditProject", new {id = bm.Id});
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            var vm = this.service.GetCreateProjectVm();
            return this.View(vm);
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectBm bm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddProject(bm);
                return RedirectToAction("AllProjects");
            }
            return RedirectToAction("CreateProject");
        }
    }
}
