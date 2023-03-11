using Microsoft.EntityFrameworkCore;
using BusinessLogic_Layer.Repositories.IServices;
using DataAccess_Layer.DBContext;
using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic_Layer.Loggers;

namespace BusinessLogic_Layer.Repositories.Services
{
    public class StudentService : IStudentService
    {
        private readonly ClgDeptStudentDbContext _dbContext;
        private readonly ILoggerManager _logger;

        public StudentService(ClgDeptStudentDbContext dbContext,ILoggerManager logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        } 


        public async Task<List<Student>> GetAll()
        {
            _logger.LogInfo("Here is info message from the GetAll in Student.");
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                return await _dbContext.Students.FromSqlRaw<Student>($"select * from Student").ToListAsync();
            }
            catch (ApiException ex) {
                transaction.Commit();
                _logger.LogWarn(ex.Message);
                throw new ApiException(ex.Message);
            }
            finally { _dbContext.Dispose(); }

        }

        public async Task<Student> GetStudentById(int id)
        {
            _logger.LogInfo("Here is info message from GetStudentById.");
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
                _logger.LogWarn(ex.Message);
                throw new ApiException(ex.Message);
            }
            finally { _dbContext.Dispose(); }

        }
        public async Task<Student> GetStudentByName(string name)
        {
            _logger.LogInfo("Here is info message from GetStudentByName ");
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
                _logger.LogWarn(ex.Message);
                throw new ApiException(ex.Message); 
            }
            finally { _dbContext.Dispose(); }

        }

        public async Task<Student> PostStudent(Student student)
        {
            _logger.LogInfo("Here is info message from the PostStudent");
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
                _logger.LogWarn(ex.Message);
                throw new ApiException(ex.Message);
            }
            finally { _dbContext.Dispose(); }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _logger.LogInfo("Here is info message from the UpdateStudent.");
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
                _logger.LogWarn(ex.Message);
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
