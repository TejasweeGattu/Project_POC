using DataAccess_Layer.FileModels;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic_Layer.Services
{
    public interface IFileService
    {
        public Task PostFile(IFormFile fileData, FileType fileType);

        public Task PostMultiFile(List<FileUploadModel> fileData);

        public Task DownloadFileById(int fileName);
    }
}
