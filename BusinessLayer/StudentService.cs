using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class StudentService
    {
        private readonly StudentRepository _repo;

        public StudentService(string connectionString)
        {
            _repo = new StudentRepository(connectionString);
        }

        public void ImportStudents(DataTable dt)
        {
            _repo.BulkInsert(dt, "Sinh_Vien");
        }

        // ✅ Lấy tổng số sinh viên trong DB
        public int GetStudentCount()
        {
            return _repo.CountStudents();
        }
    }

}
