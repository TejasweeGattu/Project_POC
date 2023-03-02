using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Repositories.IServices
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> GetStudentById(int id);
        Task<Student> GetStudentByName(string name);
        Task<Student> PostStudent(Student student);
        Task<Student> UpdateStudent(Student student);
       // public void DeleteStudent(int id);
    }
}
