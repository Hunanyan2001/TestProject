using Amazon.S3.Model;

using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IS3Service
    {
        Task<string> CreateSignedUrl(CreateSignedUrlRequest createSignedUrlRequest);
    }
}
