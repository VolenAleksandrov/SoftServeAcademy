using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HRManager.Models.BindingModels.Employee;
using HRManager.Models.EntityModels;
using HRManager.Models.EntityModels.Enums;
using HRManager.Models.ViewModels.Employee;

namespace HRManager.Services
{
    public class EmpolyeeService : Service
    {
        public List<EmployeeVm> GetAllEmployeeVms()
        {
            var employees = this.Context.Employees;
            var employeeVms = new List<EmployeeVm>();
            foreach (var employee in employees)
            {
                employeeVms.Add(MapEmployeeToEmployeeVm(employee));
            }
            return employeeVms;
        }

        public EditEmployeeVm GetEditEmployeeVm(int id)
        {
            Employee emp = this.Context.Employees.FirstOrDefault(e => e.Id == id);
            EditEmployeeVm vm = new EditEmployeeVm();
            AddAllProjectManagers(vm);
            AddAllDeliveryDirectors(vm);
            AddEmployeeProperties(vm, emp);
            AddTeamLeadsWithoutProject(vm, emp);
            vm.Projects = GetAllProjectsWithoutTeamLead();
            vm.Roles = GetAllRoles();
            return vm;
        }

        public CreateEmployeeVm GetCreateEmployeeVm()
        {
            CreateEmployeeVm vm = new CreateEmployeeVm();
            vm.Roles = GetAllRoles();
            return vm;
        }

        public Dictionary<int, string> GetAllTeamLeads()
        {
            var teamLeads =
                this.Context.Employees.Where(e => e.Role == EmployeeRole.TeamLeader);

            Dictionary<int, string> teamLeadsDictionary = new Dictionary<int, string>();
            if (teamLeads.Count() > 0)
            {
                foreach (var employee in teamLeads)
                {
                    teamLeadsDictionary.Add(employee.Id, employee.Name);
                }
            }
            return teamLeadsDictionary;
        }

        public CreateEmployeeTeamLeadPartial GetCreateEmployeeTlPartial()
        {
            var vm = new CreateEmployeeTeamLeadPartial();
            Dictionary<int, string> projectManagers = this.GetMappedProjectManagers();
            Dictionary<int, string> projectsWithoutTeamLead = GetAllProjectsWithoutTeamLead();
            return new CreateEmployeeTeamLeadPartial()
            {
                ProjectsWithoutTeamLead = projectsWithoutTeamLead,
                ProjectManagers = projectManagers
            };
        }

        public void AddEmployee(CreateEmployeeBm bm)
        {

            if (bm.Role >= 0 && bm.Role <= 3) //If is trainee, junior, intermediate or senior
            {
                var employee = CreateEmployee(bm);
                this.Context.Employees.Add(employee);
            }
            else if (bm.Role == 4) // If is teamlead
            {
                var teamLead = CreateTeamLead(bm);
                this.Context.Employees.Add(teamLead);
            }
            else if (bm.Role == 5) //If is project manager
            {
                var projectManager = CreateProjectManager(bm);
                this.Context.Employees.Add(projectManager);
            }
            else if (bm.Role == 6) //If is delivery director
            {
                var deliveryDirector = CreateDeliveryDirector(bm);
                this.Context.Employees.Add(deliveryDirector);
            }
            this.Context.SaveChanges();
        }

        public Dictionary<int, string> GetAllDeliveryDirectors()
        {
            var deliveryDirectors = this.Context.Employees.Where(e => e.Role == EmployeeRole.DeliveryDirector);
            Dictionary<int, string> ddDictionary = new Dictionary<int, string>();
            foreach (var deliveryDirector in deliveryDirectors)
            {
                ddDictionary.Add(deliveryDirector.Id, deliveryDirector.Name);
            }
            return ddDictionary;
        }
        
        private Employee CreateEmployee(CreateEmployeeBm bm)
        {
            Employee employee = new Employee()
            {
                Name = bm.Name,
                Email = bm.Email,
                Phone = bm.Phone,
                Salary = bm.Salary,
                WorkplaceCity = bm.Workplace
            };
            if (bm.Role == 0)
                employee.Role = EmployeeRole.Trainee;

            else if (bm.Role == 1)
                employee.Role = EmployeeRole.Junior;

            else if(bm.Role == 2)
                employee.Role = EmployeeRole.Intermediate;

            else employee.Role = EmployeeRole.Senior;
            if (bm.TeamLead != 0)
            {
                var teamLead = this.Context.Employees.FirstOrDefault(e => e.Id == bm.TeamLead) as TeamLead;
                employee.TeamLead = teamLead;
                if (teamLead.HasProject)
                {
                    employee.HasProject = true;
                }
            }
            return employee;
        }

        private TeamLead CreateTeamLead(CreateEmployeeBm bm)
        {
            TeamLead teamLead = new TeamLead()
            {
                Email = bm.Email,
                Salary = bm.Salary,
                Name = bm.Name,
                Phone = bm.Phone,
                Role = EmployeeRole.TeamLeader,
                WorkplaceCity = bm.Workplace
            };
            if (bm.Project != 0)
            {
                teamLead.Project = this.Context.Projects.FirstOrDefault(p => p.Id == bm.Project);
                teamLead.HasProject = true;
            }
            if (bm.ProjectManager != 0)
            {
                teamLead.ProjectManager =
                    this.Context.Employees.FirstOrDefault(e => e.Id == bm.ProjectManager) as ProjectManager;
            }
            return teamLead;
        }

        private ProjectManager CreateProjectManager(CreateEmployeeBm bm)
        {
            ProjectManager projectManager = new ProjectManager
            {
                Email = bm.Email,
                Salary = bm.Salary,
                Name = bm.Name,
                Phone = bm.Phone,
                Role = EmployeeRole.ProjectManager,
                WorkplaceCity = bm.Workplace
            };
            if (bm.DeliveryDirector != 0)
            {
                projectManager.DeliveryDirector =
                    this.Context.Employees.FirstOrDefault(e => e.Id == bm.DeliveryDirector) as DeliveryDirector;
            }
            return projectManager;
        }

        private DeliveryDirector CreateDeliveryDirector(CreateEmployeeBm bm)
        {
            DeliveryDirector deliveryDirector = new DeliveryDirector
            {
                Email = bm.Email,
                Salary = bm.Salary,
                Name = bm.Name,
                Phone = bm.Phone,
                Role = EmployeeRole.DeliveryDirector,
                WorkplaceCity = bm.Workplace
            };
            deliveryDirector.Ceo = this.Context.Employees.FirstOrDefault(e => e.Role == EmployeeRole.Ceo);
            return deliveryDirector;
        }

        private Dictionary<int, string> GetAllProjectsWithoutTeamLead()
        {
            var projects = this.Context.Projects.Where(p => p.TeamLead == null);
            Dictionary<int, string> projectsDictionary = new Dictionary<int, string>();
            foreach (var project in projects)
            {
                projectsDictionary.Add(project.Id, project.Name);
            }
            return projectsDictionary;
        }

        private Dictionary<int, string> GetMappedProjectManagers()
        {
            var managers = this.Context.Employees.Where(e => e.Role == EmployeeRole.ProjectManager);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (var manager in managers)
            {
                dictionary.Add(manager.Id, manager.Name);
            }
            return dictionary;
        }

        private EmployeeVm MapEmployeeToEmployeeVm(Employee employee)
        {
            string projectName = "Do not have project";
            string teamLeadName = "Do not have teamlead";

            if (employee.HasProject || employee.TeamLead != null)
            {
                if (employee.Role == EmployeeRole.Intermediate || employee.Role == EmployeeRole.Junior || employee.Role == EmployeeRole.Senior || employee.Role == EmployeeRole.Trainee)
                {
                    teamLeadName = employee.TeamLead.Name;
                    if (employee.HasProject)
                    {
                        projectName = employee.TeamLead.Project.Name;
                    }
                }
                if (employee.Role == EmployeeRole.TeamLeader)
                {
                    var emp = employee as TeamLead;
                    if (emp.HasProject)
                    {
                        projectName = emp.Project.Name;
                    }
                }
            }

            EmployeeVm vm = new EmployeeVm()
            {
                Id = employee.Id,
                Email = employee.Email,
                Name = employee.Name,
                Phone = employee.Phone,
                Role = employee.Role,
                Salary = employee.Salary,
                ProjectName = projectName,
                TeamLead = teamLeadName,
                Workplace = employee.WorkplaceCity
            };
            return vm;
        }

        private static Dictionary<int, string> GetAllRoles()
        {
            var roles = new Dictionary<int, string>()
                {
                    {0, "Trainee" },
                    {1, "Junior" },
                    {2, "Intermediate" },
                    {3, "Senior" },
                    {4, "Team leader" },
                    {5, "Project manager" },
                    {6, "Delivery director" }
                };
            return roles;
        }

        private static void AddEmployeeProperties(EditEmployeeVm vm, Employee emp)
        {
            vm.Name = emp.Name;
            vm.Email = emp.Email;
            vm.Phone = emp.Phone;
            vm.Salary = emp.Salary;
            vm.Workplace = emp.WorkplaceCity;
            vm.CurrentRole = emp.Role.ToString();
        }

        private void AddAllDeliveryDirectors(EditEmployeeVm vm)
        {
            List<Employee> pjs =
                this.Context.Employees.Where(e => e.Role == EmployeeRole.DeliveryDirector).ToList();
            foreach (var pj in pjs)
            {
                vm.DeliveryDirectors.Add(pj.Id, pj.Name);
            }
        }

        private void AddAllProjectManagers(EditEmployeeVm vm)
        {
            List<Employee> pjs =
                this.Context.Employees.Where(e => e.Role == EmployeeRole.ProjectManager).ToList();
            foreach (var pj in pjs)
            {
                vm.ProjectManagers.Add(pj.Id, pj.Name);
            }
        }

        private void AddTeamLeadsWithoutProject(EditEmployeeVm vm, Employee emp)
        {
            List<Employee> tls =
                this.Context.Employees.Where(e => e.Role == EmployeeRole.TeamLeader && e.HasProject == false).ToList();
            foreach (var teamLead in tls)
            {
                vm.TeamLeads.Add(teamLead.Id, teamLead.Name);
            }
            if (emp.TeamLead != null)
            {
                vm.TeamLeads.Add(emp.TeamLead.Id, emp.TeamLead.Name);
            }
        }

        public void EditEmplyee(EditEmployeeBm bm)
        {
            if (bm.Role == 10)
            {
                var emp = this.Context.Employees.FirstOrDefault(e => e.Id == bm.Id);
                if (emp.Role == EmployeeRole.ProjectManager)
                {
                    if (bm.DeliveryDirector != 0)
                    {
                        DeliveryDirector dd =
                            this.Context.Employees.FirstOrDefault(e => e.Id == bm.Id) as DeliveryDirector;
                        var employee = emp as ProjectManager;
                        employee.DeliveryDirector = dd;
                    }
                    this.Context.SaveChanges();
                }
                if (emp.Role == EmployeeRole.TeamLeader)
                {
                    var employee = emp as TeamLead;
                    if (bm.Project != 0)
                    {
                        var proj = this.Context.Projects.FirstOrDefault(p => p.Id == bm.Project);
                        employee.Project = proj;
                        employee.HasProject = true;
                    }
                    if (bm.ProjectManager != 0)
                    {
                        var pm = this.Context.Employees.FirstOrDefault(e => e.Id == bm.ProjectManager) as ProjectManager;
                        employee.ProjectManager = pm;
                    }
                    this.Context.SaveChanges();
                }
                if (emp.Role == EmployeeRole.Senior || emp.Role == EmployeeRole.Trainee ||
                    emp.Role == EmployeeRole.Intermediate || emp.Role == EmployeeRole.Junior)
                {
                    if (bm.TeamLead != 10)
                    {
                        var tl = this.Context.Employees.FirstOrDefault(e => e.Id == bm.TeamLead) as TeamLead;
                        emp.TeamLead = tl;
                    }
                    this.Context.SaveChanges();
                }
            }
            else
            {
                var emp = this.Context.Employees.FirstOrDefault(e => e.Id == bm.Id);
                this.Context.Employees.Remove(emp);
                if (bm.Role == 0 || bm.Role == 1 || bm.Role == 2 || bm.Role == 3)
                {
                    var employee = new Employee()
                    {
                        Email = bm.Email,
                        Salary = bm.Salary,
                        Name = bm.Name,
                        Phone = bm.Phone,
                        WorkplaceCity = bm.Workplace,
                        Role = (EmployeeRole)bm.Role
                    };
                    if (bm.TeamLead != 0)
                    {
                        TeamLead tl = this.Context.Employees.FirstOrDefault(e => e.Id == bm.TeamLead) as TeamLead;
                        employee.TeamLead = tl;
                        tl.ProjectColleagues.Add(tl);
                    }
                    if (employee.TeamLead != null)
                    {
                        if (employee.TeamLead.HasProject && employee.TeamLead != null)
                        {
                            employee.HasProject = true;
                        }
                    }
                    this.Context.Employees.Add(employee);
                }
                else if (bm.Role == 4)
                {
                    TeamLead employee = new TeamLead()
                    {
                        Email = bm.Email,
                        Salary = bm.Salary,
                        Name = bm.Name,
                        Phone = bm.Phone,
                        WorkplaceCity = bm.Workplace,
                        Role = (EmployeeRole) bm.Role,
                    };
                    if (bm.ProjectManager != 0)
                    {
                        employee.ProjectManager =
                            this.Context.Employees.FirstOrDefault(e => e.Id == bm.ProjectManager) as ProjectManager;
                    }
                    if (bm.Project != 0)
                    {
                        employee.Project = this.Context.Projects.FirstOrDefault(p => p.Id == bm.Id);
                    }
                    this.Context.Employees.Add(employee);
                }
                else if (bm.Role == 5)
                {
                    ProjectManager pm = new ProjectManager()
                    {
                        Email = bm.Email,
                        Salary = bm.Salary,
                        Name = bm.Name,
                        Phone = bm.Phone,
                        WorkplaceCity = bm.Workplace,
                        Role = (EmployeeRole) bm.Role,
                        DeliveryDirector =
                            this.Context.Employees.FirstOrDefault(e => e.Id == bm.DeliveryDirector) as DeliveryDirector
                    };
                    if (bm.DeliveryDirector != 0)
                    {
                        pm.DeliveryDirector =
                            this.Context.Employees.FirstOrDefault(e => e.Id == bm.DeliveryDirector) as DeliveryDirector;
                    }
                    this.Context.Employees.Add(pm);
                }
                else if (bm.Role == 6)
                {
                    DeliveryDirector dd = new DeliveryDirector()
                    {
                        Email = bm.Email,
                        Salary = bm.Salary,
                        Name = bm.Name,
                        Phone = bm.Phone,
                        WorkplaceCity = bm.Workplace,
                        Role = (EmployeeRole) bm.Role,
                        Ceo = this.Context.Employees.Find(1)
                    };
                    this.Context.Employees.Add(dd);
                }
            }
            this.Context.SaveChanges();
        }
    }
}