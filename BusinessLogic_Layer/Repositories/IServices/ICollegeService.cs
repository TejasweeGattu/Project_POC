using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Repositories.IServices
{
    public interface ICollegeService
    {
        // IEnumerable<College> GetAll();
        //College GetCollegeById(int id);
        //College GetCollegeById(int id);
        Task<List<College>> GetAll();
        Task<College> GetCollegeById(int id);
        Task<College> GetCollegeByName(string name);
        Task<College> PostCollege(College college);
        Task<College> Update(College clg);
        //int Update(int clg);
      // void DeleteCollegeById(int id);

    }
}
