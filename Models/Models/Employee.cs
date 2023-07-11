using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzkaTask_Solution.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Qualifications { get; set; }
        public bool IsDeleted { get; set; } 
        public List<Vacation>? Vacation { get; set; }

 


    }
}
