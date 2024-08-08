using Microsoft.AspNetCore.Mvc;

using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly IS3Service _s3Service;

        public UploadController(IS3Service s3Service)
        {
            _s3Service = s3Service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSignedUrlRequest createSignedUrlRequest)
        {
            return Ok(await _s3Service.CreateSignedUrl(createSignedUrlRequest));
        }
    }
}
