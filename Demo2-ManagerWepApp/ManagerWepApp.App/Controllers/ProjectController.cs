using System.Web.Mvc;
using ManagerWepApp.Models.ViewModels;
using ManagerWepApp.Services;

namespace ManagerWepApp.App.Controllers
{
    [RoutePrefix("project")]
    public class ProjectController : Controller
    {
        private ProjectService service;

        public ProjectController()
        {
            this.service = new ProjectService();
        }

        [HttpGet]
        [Route("all")]
        public ActionResult AllProjects()
        {
            return View();
        }

        [HttpGet]
        [Route("create")]
        public ActionResult CreateProject()
        {
            CreateProjectVm vm = service.GetProjectVm();
            return View(vm);
        }

        [HttpPost, Route("create")]
        public ActionResult CreateProject(CreateProjectVm vm)
        {
            if (this.ModelState.IsValid)
            {
                service.AddProject(vm);
                return this.RedirectToAction("AllProjects");
            }
            return this.RedirectToAction("CreateProject");
        }
        
    }
}