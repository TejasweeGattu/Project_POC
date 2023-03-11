using DataAccess_Layer.FileModels;
using BusinessLogic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Files_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _uploadService;

        public FilesController(IFileService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            try
            {
                if (fileDetails == null)
                {
                    return BadRequest();
                }
                await _uploadService.PostFile(fileDetails.FileDetails, fileDetails.FileType);
                return Ok("File uploaded successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("PostMultipleFile")]
        public async Task<ActionResult> PostMultipleFile([FromForm] List<FileUploadModel> fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.PostMultiFile(fileDetails);
                return Ok("Files uploaded successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.DownloadFileById(id);
                return Ok("File downloaded successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
