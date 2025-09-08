using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
            public string checkTextBox(string maSV)
        {
            if(string.IsNullOrEmpty(maSV))
            {
                return null;
            }
                return maSV;
        }

        }
    }

