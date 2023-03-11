using Microsoft.AspNetCore.Http;

namespace DataAccess_Layer.FileModels
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }
    }
}
