using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManager.Models.BindingModels.Employee;
using HRManager.Models.ViewModels.Employee;
using HRManager.Services;

namespace HRManager.App.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpolyeeService service;
        public EmployeeController()
        {
            this.service = new EmpolyeeService();
        }
        // GET: Employee
        [HttpGet]
        public ActionResult AllEmployees()
        {
            List<EmployeeVm> vm = this.service.GetAllEmployeeVms();
            return this.View(vm);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            CreateEmployeeVm vm = this.service.GetCreateEmployeeVm();
            return this.View(vm);
        }

        [HttpPost]
        public ActionResult CreateEmployee(CreateEmployeeBm bm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddEmployee(bm);
                return RedirectToAction("AllEmployees");
            }
            return RedirectToAction("CreateEmployee");
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            EditEmployeeVm vm = this.service.GetEditEmployeeVm(id);
            return this.View(vm);
        }

        public ActionResult EditEmployee(EditEmployeeBm bm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditEmplyee(bm);
                return this.RedirectToAction("AllEmployees");
            }
            return this.RedirectToAction("EditEmployee", new {id = bm.Id});
        }

        [HttpGet]
        public PartialViewResult GetPartialView(int id)
        {
            if (id == 0 || id == 1 || id == 2 || id == 3)
            {
                Dictionary<int, string> teamLeads = this.service.GetAllTeamLeads();
                return this.PartialView("_EmployeeTJIS", teamLeads);
            }
            else if (id == 4)
            {
                CreateEmployeeTeamLeadPartial vm = this.service.GetCreateEmployeeTlPartial();
                return this.PartialView("_CreateEmployeeTeamLead", vm);
            }
            else if (id == 5)
            {
                Dictionary<int, string> vm = this.service.GetAllDeliveryDirectors();
                return this.PartialView("_CreateEmployeeProjectManagers", vm);
            }
            return null;
        }
    }
}