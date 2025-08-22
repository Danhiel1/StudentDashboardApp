using DataAccessLayer;

namespace BusinessLayer
    {
        public class StudentService
        {
            public List<Student> GetAllStudents()
            {
                using (var db = new StudentDbContext())
                {
                    return db.Students.ToList();
                }
            }
        }
    }

