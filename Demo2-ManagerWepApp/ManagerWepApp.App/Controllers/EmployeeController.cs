using System.Web.Mvc;
using ManagerWepApp.Models.EntityModels;
using ManagerWepApp.Models.ViewModels.Employee;
using ManagerWepApp.Models.ViewModels.Employees;
using ManagerWepApp.Models.ViewModels.ProjectManager;
using ManagerWepApp.Models.ViewModels.TeamLead;
using ManagerWepApp.Services;
using Microsoft.ApplicationInsights.WindowsServer;

namespace ManagerWepApp.App.Controllers
{
    [RoutePrefix("employee")]
    public class EmployeeController : Controller
    {
        private EmployeeService service;

        public EmployeeController()
        {
            this.service = new EmployeeService();
        }

        [HttpGet]
        [Route("all")]
        public ActionResult AllEmployees()
        {
            return this.View();
        }

        [HttpGet]
        [Route("add/deliveryDirector")]
        public ActionResult CreateDeliveryDirector()
        {
            return View(new CreateDeliveryDirectorVm());
        }

        [HttpPost]
        [Route("add/deliveryDirector")]
        public ActionResult CreateDeliveryDirector(CreateDeliveryDirectorVm vm)
        {
            if (ModelState.IsValid)
            {
                this.service.AddDeliveryDirector(vm);
                return this.RedirectToAction("AllEmployees");
            }
            return this.RedirectToAction("CreateDeliveryDirector");
        }
        [HttpGet]
        [Route("add/projectManager")]
        public ActionResult CreateProjectManager()
        {
            return View(new CreateProjectManagerVm());
        }
        [HttpPost]
        [Route("add/projectManager")]
        public ActionResult CreateDeliveryDirector(CreateProjectManagerVm vm)
        {
            if (ModelState.IsValid)
            {
                this.service.AddProjectManager(vm);
                return this.RedirectToAction("AllEmployees");
            }
            return this.RedirectToAction("CreateProjectManager");
        }
        [HttpGet]
        [Route("add/teamLead")]
        public ActionResult CreateTeamLead()
        {
            return View(new CreateTeamLeadVm());
        }
        [HttpPost]
        [Route("add/teamLead")]
        public ActionResult CreateDeliveryDirector(CreateTeamLeadVm vm)
        {
            if (ModelState.IsValid)
            {
                this.service.AddTeamLead(vm);
                return this.RedirectToAction("AllEmployees");
            }
            return this.RedirectToAction("CreateTeamLead");
        }
        [HttpGet]
        [Route("add/employee")]
        public ActionResult CreateEmployee()
        {
            return View(new CreateEmployeeVm());
        }
        [HttpPost]
        [Route("add/employee")]
        public ActionResult CreateEmployee(CreateEmployeeVm vm)
        {
            if (ModelState.IsValid)
            {
                this.service.AddEmployee(vm);
                return this.RedirectToAction("AllEmployees");
            }
            return this.RedirectToAction("CreateTeamLead");
        }
    }
}