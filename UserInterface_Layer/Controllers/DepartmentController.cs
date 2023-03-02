using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic_Layer.Repositories.IServices;

using DataAccess_Layer.Models;
using DataAccess_Layer.DTO;

namespace UserInterface_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _idepartmentService;
        public DepartmentController(IDepartmentService idepartmentService) => _idepartmentService = idepartmentService;


        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetAll() => Ok(await _idepartmentService.GetAll());


        [HttpGet("GetDepartmentsById")]
        public async Task<IActionResult> GetDept(int id) => Ok(await _idepartmentService.GetDepartmentsById(id));

        [HttpGet("GetDepartmentsByName")]
        public async Task<IActionResult> GetDept(string name) => Ok(await _idepartmentService.GetDepartmentsByName(name));


        [HttpPost("AddDepartments")]
        public IActionResult Create([FromBody] Dto department)
        {
            try
            {
                var dept = _idepartmentService.PostDepartment(department);
                if (dept == null)
                {
                    return BadRequest();
                }
                return Ok(dept);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            return BadRequest();
        }

        [HttpPut("UpdateDepartments")]
        public async Task<IActionResult> UpdateDeptartment(Department department) => Ok(await _idepartmentService.UpdateDept(department));


        //[HttpDelete("DeleteDept")]
        //public Task<IActionResult> DeleteDept(string name)
        //{
        //    try
        //    {
        //        _idepartmentService.DeleteDepartment(name);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new ArgumentException(ex.Message);
        //    }
        //    return BadRequest();
        //}



    }
}
