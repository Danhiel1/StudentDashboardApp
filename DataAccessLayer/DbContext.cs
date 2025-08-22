using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=QLSV;Trusted_Connection=True;");
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
