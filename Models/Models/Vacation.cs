
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzkaTask_Solution.Models
{
    public class Vacation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool IsDeleted { get; set; }
        public Employee Employee { get; set; }
    }
}
