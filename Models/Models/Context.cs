using Microsoft.EntityFrameworkCore;

namespace AzkaTask_Solution.Models
{
    public class Context :DbContext
    {
        public Context() { }

        //inJection

        public Context(DbContextOptions option) : base(option)
        {

        }
       
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Vacation> Vacation { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MAHMOUD-EMAD\\SQL19;Initial Catalog=AzkaTask;Integrated Security=True;Encrypt=False");
        }
    }
}
