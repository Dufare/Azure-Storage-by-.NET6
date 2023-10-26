using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Storage_Azure.Model;
using Storage_Azure.Services;

namespace Storage_Azure.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FileController : Controller
    {
        private readonly IFileServices _fileService;

        public FileController(IFileServices fileService)
        {
            _fileService = fileService;

        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Uplaod([FromForm] FileModel file)
        {
            await _fileService.Upload(file);
            return Ok("success");
        }


        [HttpPost]
        [Route("CreateC")]
        public async Task<IActionResult> CreateContainers(BlobServiceClient blobServiceClient)
        {
            await _fileService.CreateContanier(blobServiceClient);
            return Ok("success");
        }
    }
}
