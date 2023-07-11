using AzkaTask_Solution.BLL;
using AzkaTask_Solution.Models;
using AzkaTask_Solution.ViewModels;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceStack;

namespace AzkaTask_Solution.Controllers
{
    public class VacationController : Controller
    {
        private readonly IVacationService vacationService;
        private readonly IEmployeeService employeeService;

        public VacationController(IVacationService vacationService, IEmployeeService employeeService)
        {
            this.vacationService = vacationService;
            this.employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult VacationsOfEmployee(int id)
        {
            List<string> types = new List<string>
                {
                    "Sick leave",
                    "Paid vacation",
                    "Unpaid vacation",
                    "Maternity leave",
                    "Paternity leave"
                };

            IEnumerable<SelectListItem> typeList = types.Select(d => new SelectListItem { Text = d, Value = d });

            ViewData["Types"] = typeList;

            List<Vacation> vacations = vacationService.GetAllVacationsForSpecificEmployee(id);
            Employee employee = employeeService.GetEmployeeByID(id);
            int TotalDuration = 0;
            foreach (var item in vacations.Where(vac => vac.IsDeleted == false))
            {
                TotalDuration += item.Duration;
            }
            ViewData["Duration"] = TotalDuration;
            ViewData["Vacations"] = vacations;

            VacationViewModel Newvacation = new VacationViewModel();
            Newvacation.EmployeeName = employee.Name;
            Newvacation.EmployeeId = employee.Id;
            Newvacation.StartDate = DateTime.Now;
            return View(Newvacation);
        }

        public ActionResult Delete(int VacId, int id)
        {

            vacationService.Delete(VacId);

            return RedirectToAction("VacationsOfEmployee", new { id = id });

        }

        [HttpPost]
        public ActionResult VacationsOfEmployee(VacationViewModel vacation)
        {
            List<string> types = new List<string>
                {
                    "Sick leave",
                    "Paid vacation",
                    "Unpaid vacation",
                    "Maternity leave",
                    "Paternity leave"
                };

            IEnumerable<SelectListItem> typeList = types.Select(d => new SelectListItem { Text = d, Value = d });

            Employee emp = employeeService.GetEmployeeByID((int)vacation.EmployeeId);
            ViewData["Types"] = typeList;
            List<Vacation> vacations = vacationService.GetAllVacationsForSpecificEmployee(emp.Id);
            int TotalDuration = 0;
            foreach (var item in vacations)
            {
                TotalDuration += item.Duration;
            }
            ViewData["Duration"] = TotalDuration;
            ViewData["Vacations"] = vacations;

            if (ModelState.IsValid)
            {



                DateTime currentDate = vacation.StartDate;
                DateTime endDate = currentDate.AddDays(vacation.Duration);

                bool isVacationOngoing = false;

                // Check if any vacation in the employee's list is still ongoing
                foreach (var empVacation in emp.Vacation)
                {
                    DateTime vacationEndDate = empVacation.StartDate.AddDays(empVacation.Duration);

                    if (currentDate <= vacationEndDate && endDate >= empVacation.StartDate)
                    {
                        // There is an ongoing vacation, set the flag and break the loop
                        isVacationOngoing = true;
                        break;
                    }
                }

                if (!isVacationOngoing)
                {
                    // No ongoing vacations, proceed with creating a new vacation
                    Vacation newVacation = new Vacation
                    {
                        EmployeeId = vacation.EmployeeId,
                        StartDate = vacation.StartDate,
                        Duration = vacation.Duration,
                        Type = vacation.Type
                    };

                    vacationService.AddVacation(newVacation);
                    
                    employeeService.UpdateEmployee(emp);
                    return RedirectToAction("VacationsOfEmployee", new { id = emp.Id });
                }
                else
                {
                    return View(vacation);
                }

            }

            return View(vacation);
        }

        

    }
}
