using AzkaTask_Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EmployeeDAL
    {
        Context _context;

        public EmployeeDAL(Context context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employee.Include(emp => emp.Vacation).Where(emp=> emp.IsDeleted == false).ToList();
        }
        
        public Employee GetEmployeeByID(int id)
        {
            return _context.Employee.Include("Vacation").FirstOrDefault(emp => emp.Id == id && emp.IsDeleted == false);
        }
         public Employee GetEmployeeByName(string Name)
        {
            return _context.Employee.Include("Vacation").FirstOrDefault(emp => emp.Name == Name && emp.IsDeleted == false);
        }
        
        public void AddEmployee(Employee employee)
        {
             _context.Employee.Add(employee);
            _context.SaveChanges();
        }
        
        public void DeleteEmployee(int id)
        {
             Employee employee = _context.Employee.Include("Vacation").First(emp => emp.Id == id && emp.IsDeleted == false);
             employee.IsDeleted= true;
            foreach (var item in employee.Vacation)
            {
                item.IsDeleted= true;
            }
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee UpdatedEmployee)
        {
            Employee employee1 = _context.Employee.Include("Vacation").FirstOrDefault(emp => emp.Id== UpdatedEmployee.Id && emp.IsDeleted == false);
            employee1.BirthDate = UpdatedEmployee.BirthDate;
            employee1.Name = UpdatedEmployee.Name;
            employee1.Qualifications = UpdatedEmployee.Qualifications;
            employee1.Vacation = UpdatedEmployee.Vacation;
            _context.SaveChanges();
        }



    }
}