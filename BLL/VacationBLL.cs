using AzkaTask_Solution.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IVacationService
    {
        List<Vacation> GetAllVacationsForSpecificEmployee(int id);
        void AddVacation(Vacation vacation);
        void Delete(int VacId);
      
    }
    public class VacationService : IVacationService
    { 

    VacationDAL _vacation;
    public VacationService(VacationDAL vacation)
    {

       _vacation = vacation;

    }
    public List<Vacation> GetAllVacationsForSpecificEmployee(int id)
    {

        return _vacation.GetAllVacationsForSpecificEmployee(id);
    }

    

    public void AddVacation(Vacation vacation)
    {
        _vacation.AddVacation(vacation);
    }

        public void Delete(int VacId)
        {
            _vacation.DeleteVacation(VacId);
        }
    }
}
