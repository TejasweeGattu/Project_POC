using Microsoft.EntityFrameworkCore;
using BusinessLogic_Layer.Repositories.IServices;
using DataAccess_Layer.DBContext;
using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BusinessLogic_Layer.Repositories.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ClgDeptStudentDbContext _dbContext;

        public DepartmentService(ClgDeptStudentDbContext dbContext) => _dbContext = dbContext;


        public async Task<List<Department>> GetAll()
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var obj = await _dbContext.Departments.Include(c => c.Students).ToListAsync();
                return obj;

            }
            catch (ApiException ex)
            {
                transaction.Commit();
                transaction.Rollback();
                throw new ApiException(ex.Message);
            }
            finally { transaction.Dispose(); }

        }

        public async Task<Department> GetDepartmentsById(int id)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var dept = _dbContext.Departments.FirstOrDefault(c => c.Did == id);
                if (dept == null)
                {
                    throw new ApiException("Not found");
                }
                return dept;
            }
            catch (ApiException ex)
            {
                transaction.Commit();
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Department> GetDepartmentsByName(string name)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var dept = _dbContext.Departments.FirstOrDefault(c => c.Dname == name);
                if (dept == null)
                {
                    throw new ApiException("Not found");
                }
                return dept;
            }
            catch (ApiException ex)
            {
                transaction.Commit();
                throw new ApiException(ex.Message);
            }

        }

        public Department PostDepartment(Dto department)
        {
            try
            {
                var college = _dbContext.Colleges.FirstOrDefault(x => x.Cname == department.Cname);
                Department department1 = new Department()
                {
                    Cid = college.Cid,
                    Dname = department.Dname,
                    Dblock = department.Dblock,
                    Dhod = department.Dhod,
                    ActiveFlag = department.ActiveFlag,
                    CreatedBy = "Teju",
                    CreatedDate = DateTime.Now,

                };
                _dbContext.Departments.AddAsync(department1);
                _dbContext.SaveChanges();
                return department1;
            }
            catch (ApiException ex)
            {

                throw new ApiException(ex.Message);
            }
            return null;
        }

        public async Task<Department> UpdateDept(Department department)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _dbContext.Departments.Update(department);
                _dbContext.SaveChangesAsync();
                return department;
            }
            catch (ApiException ex)
            {
                transaction.Commit();
                throw new ApiException(ex.Message);
            }

        }

        public string DeleteDepartment(string name)
        {
            try
            {
                var query = $@"update [dbo].[Department] set ActiveFlag=0 from [dbo].[College] as c, [dbo].[Department] as d where c.Cid=d.Cid and c.CName={name}";
                 _dbContext.Departments.FromSqlRaw<Department>(query);
                
                return "Soft delete completed";
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }


        }

        //public string DeleteById(string name)
        //{
        //    try
        //    {
        //        var query = $"update[dbo].[Department] set Activeflag = 0 from[dbo].[College] as c,[dbo].[Department] as d where c.id = d.Cid and c.Cname = '@name'";
        //        _context.Students.FromSqlRaw(query);
        //        return "Record Deleted Sucessfully";
        //    }
        //    catch (BadRequest e)
        //    {
        //        throw new BadRequest($"Could not delete {e.Message}");
        //    }
        //}
    }
}
