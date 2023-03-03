using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic_Layer.Repositories.IServices;
using DataAccess_Layer.Models;

namespace UserInterface_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _icollegeService;

      
        public CollegeController(ICollegeService icollegeService)=>_icollegeService = icollegeService;

     
        [HttpGet("GetColleges")]
        public async Task<IActionResult> GetAll()=>Ok(await _icollegeService.GetAll());



        [HttpGet("GetCollegesById")]

        public async Task<IActionResult> GetColleges(int id)=>Ok(await _icollegeService.GetCollegeById(id));

        [HttpGet("GetCollegesByName")]

        public async Task<IActionResult> GetColleges(string name) => Ok(await _icollegeService.GetCollegeByName(name));
   


        [HttpPost("AddColleges")]
        public async Task<IActionResult> Post([FromBody] College clg)=>Ok(await _icollegeService.PostCollege(clg));


        //[HttpPut("UpdateCollege")]
        //public async Task<ActionResult> UpdateCollege([FromBody] College clg) => Ok(await _icollegeService.Update(clg));
        
        //[HttpDelete("DeleteCollegeById")]

        //public IActionResult DeleteColleges(int id)
        //{

        //    //_logger.LogInformation("Logs for delete method");
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _icollegeService.DeleteCollegeById(id);
        //            return Ok(new { message = "User deleyed" });
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        //   _logger.LogCritical(e.Message, e.InnerException);
        //        throw new ArgumentException(e.Message);

        //    }
        //    return BadRequest();

        //}
    }
}
