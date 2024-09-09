using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        public class UploadModel
        {
            public IList<IFormFile> Files { get; set; }
        }

        private readonly string _uploadFolderPath = Environment.GetEnvironmentVariable("EXPLORER_IMAGE_PATH") ?? "/var/www/images";
        private readonly long _maxFileSize = 5 * 1024 * 1024; // 5 MB
        private readonly List<string> _allowedFileTypes = new List<string> { "image/jpeg", "image/jpg" , "image/png", "image/gif", "image/svg+xml" };


        public UploadController()
        {
            if (!Directory.Exists(_uploadFolderPath))
            {
                Directory.CreateDirectory(_uploadFolderPath);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UploadFiles([FromForm] UploadModel model)
        {
            if (model.Files == null || model.Files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }


            foreach (var file in model.Files)
            {
                if (file.Length == 0) 
                    return BadRequest("One or more files are empty.");

                if (!_allowedFileTypes.Contains(file.ContentType)) 
                    return BadRequest($"Invalid file type: {file.ContentType}. Allowed types are: {string.Join(", ", _allowedFileTypes)}.");
                
                if (file.Length > _maxFileSize) 
                    return BadRequest($"File size exceeds the limit of {_maxFileSize / (1024 * 1024)} MB.");
             
            }

            var uploadedFiles = new List<string>();

            foreach (var file in model.Files)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var uniqueFileName = $"{Guid.NewGuid().ToString()}{fileExtension}";
                var filePath = Path.Combine(_uploadFolderPath, uniqueFileName);
        

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                uploadedFiles.Add($"/images/{uniqueFileName}");
                
            }
            

            return Ok(new {FilePaths = uploadedFiles});
        }

    }
}
