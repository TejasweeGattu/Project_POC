using Microsoft.EntityFrameworkCore;
using BusinessLogic_Layer.Repositories.IServices;
using DataAccess_Layer.DBContext;
using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Repositories.Services
{
    public class StudentService : IStudentService
    {
        private readonly ClgDeptStudentDbContext _dbContext;

        public StudentService(ClgDeptStudentDbContext dbContext) => this._dbContext = dbContext;


        public async Task<List<Student>> GetAll()
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                return await _dbContext.Students.FromSqlRaw<Student>($"select * from Student").ToListAsync();
            }
            catch (ApiException ex) {
                transaction.Commit();
                throw new ApiException(ex.Message);
            }
            finally { _dbContext.Dispose(); }

        }

        public async Task<Student> GetStudentById(int id)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var std = _dbContext.Students.Find(id);
                if (std == null)
                {
                    throw new ApiException("Not found");
                }
                return std;
            }
            catch (ApiException ex) {
                transaction.Commit();
                throw new ApiException(ex.Message);
            }
            finally { _dbContext.Dispose(); }

        }
        public async Task<Student> GetStudentByName(string name)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var std = _dbContext.Students.Find(name);
                if (std == null)
                {
                    throw new ApiException("Not found");
                }
                return std;
            }
            catch (ApiException ex) {
                transaction.Commit();
                throw new ApiException(ex.Message); 
            }
            finally { _dbContext.Dispose(); }

        }

        public async Task<Student> PostStudent(Student student)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return student;
            }
            catch (ApiException ex) 
            {
                transaction.Commit();
                throw new ApiException(ex.Message);
            }
            finally { _dbContext.Dispose(); }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _dbContext.Students.Update(student);
                _dbContext.SaveChangesAsync();
                return student;
            }
            catch (ApiException ex)
            {
                transaction.Commit();
                throw new ApiException(ex.Message);
            }
            finally { _dbContext.Dispose(); }

        }

        //public void DeleteStudent(int id)
        //{
        //    try
        //    {
        //        var getStudentDetailsById = GetStudentById(id);
        //        _dbContext.Students.Remove(getStudentDetailsById);
        //        _dbContext.SaveChangesAsync();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new ArgumentException(ex.Message);
        //    }
        //    finally { _dbContext.Dispose(); }


        //}
    }
}
