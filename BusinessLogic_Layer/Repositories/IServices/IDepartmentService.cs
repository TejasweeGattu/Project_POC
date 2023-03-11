using DataAccess_Layer.DTO;
using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Repositories.IServices
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAll();
        Task<Department> GetDepartmentsById(int id);
        Task<Department> GetDepartmentsByName(string name);
        // Task<Department> PostDepartment(Department department);
        Department PostDepartment(Dto department);
        Task<Department> UpdateDept(Department department);
        string DeleteDepartment(string name);
    }
}
