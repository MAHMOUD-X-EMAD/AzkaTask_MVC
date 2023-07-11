using AzkaTask_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VacationDAL
    {
        Context _context;

        public VacationDAL(Context context)
        {
            _context = context;
        }

        public List<Vacation> GetAllVacationsForSpecificEmployee(int id)
        {
            return _context.Vacation.Where(va => va.EmployeeId == id && va.IsDeleted == false).ToList();
        }


        public void AddVacation(Vacation vacation)
        {
            _context.Vacation.Add(vacation);
            _context.SaveChanges();
        }

        public void DeleteVacation(int id)
        {

            Vacation vacation = _context.Vacation.FirstOrDefault(va => va.Id == id && va.IsDeleted == false);

            vacation.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
