using AzkaTask_Solution.Models;
using DAL;

namespace AzkaTask_Solution.BLL
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByID(int id);
        Employee GetEmployeeByName(string Name);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        EmployeeDAL employeeData;
        public EmployeeService(EmployeeDAL employeeDAL) {

            this.employeeData = employeeDAL;
        
        }
        public List<Employee> GetAllEmployees()
        {
           
            return employeeData.GetAllEmployees();
        }

        public Employee GetEmployeeByID(int id)
        {
            
            return employeeData.GetEmployeeByID(id);
        }
         public Employee GetEmployeeByName(string Name)
        {
            
            return employeeData.GetEmployeeByName(Name);
        }

        public void AddEmployee(Employee employee)
        {

            employeeData.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {

            employeeData.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            employeeData.DeleteEmployee(id);
        }
    }
}
