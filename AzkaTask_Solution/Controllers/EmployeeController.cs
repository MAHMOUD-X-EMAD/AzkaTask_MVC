using Microsoft.AspNetCore.Mvc;
using AzkaTask_Solution.BLL;
using AzkaTask_Solution.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL;
using AzkaTask_Solution.ViewModels;

namespace AzkaTask_Solution.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IVacationService vacationService;

        public EmployeeController(IEmployeeService employeeService, IVacationService vacationService)
        {
            this.employeeService = employeeService;
            this.vacationService = vacationService;
        }

        public ActionResult Index(int page = 1)
        {
            List<Employee> employees = employeeService.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<string> degrees = new List<string>
    {
        "Bachelors",
        "Masters",
        "PhD",
        "Associate",
        "Diploma"
    };
            IEnumerable<SelectListItem> degreeList = degrees.Select(d => new SelectListItem { Text = d, Value = d });

            ViewData["Degrees"] = degreeList;
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeeViewModel employee)
        {
            List<string> degrees = new List<string>
    {
        "Bachelors",
        "Masters",
        "PhD",
        "Associate",
        "Diploma"
    };
            IEnumerable<SelectListItem> degreeList = degrees.Select(d => new SelectListItem { Text = d, Value = d });

            ViewData["Degrees"] = degreeList;

            if (ModelState.IsValid)
            {
                Employee existingEmployee = employeeService.GetEmployeeByName(employee.Name);
                if (existingEmployee == null)
                {
                    Employee newEmployee = new Employee
                    {
                        Name = employee.Name,
                        BirthDate = employee.BirthDate,
                        Qualifications = employee.Qualifications
                    };

                    employeeService.AddEmployee(newEmployee);
                    return RedirectToAction("Index");
                }
            }

            return View(employee);
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            List<string> degrees = new List<string>
                {
                    "Bachelors",
                    "Masters",
                    "PhD",
                    "Associate",
                    "Diploma"
                };
            IEnumerable<SelectListItem> degreeList = degrees.Select(d => new SelectListItem { Text = d, Value = d });

            ViewData["Degrees"] = degreeList;
            Employee emp = employeeService.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpGet]
        public ActionResult GetEmployee(int id)
        {
            List<string> degrees = new List<string>
                {
                    "Bachelors",
                    "Masters",
                    "PhD",
                    "Associate",
                    "Diploma"
                };
            IEnumerable<SelectListItem> degreeList = degrees.Select(d => new SelectListItem { Text = d, Value = d });

            ViewData["Degrees"] = degreeList;
            Employee emp = employeeService.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            List<string> degrees = new List<string>
                {
                    "Bachelors",
                    "Masters",
                    "PhD",
                    "Associate",
                    "Diploma"
                };
            IEnumerable<SelectListItem> degreeList = degrees.Select(d => new SelectListItem { Text = d, Value = d });

            ViewData["Degrees"] = degreeList;
            if (ModelState.IsValid)
            {
                Employee existingEmployee = employeeService.GetEmployeeByName(employee.Name);
                if (existingEmployee == null)
                {
                    employeeService.UpdateEmployee(employee);
                    return RedirectToAction("Index");
                }
            }

            return View(employee);
        }

        public ActionResult Delete(int id, int page)
        {

            employeeService.DeleteEmployee(id);

            return RedirectToAction("Index", page);

        }



        // Other controller actions...
    }
}
