using Amazon.S3;
using Amazon.S3.Model;

using Microsoft.Extensions.Options;

using WebApplication1.Configuration;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class S3Service : IS3Service
    {
        private readonly IS3Options _s3Option;

        public S3Service(IOptions<S3Options> s3Option)
        {
            _s3Option = s3Option.Value;
        }

        public async Task<string> CreateSignedUrl(CreateSignedUrlRequest createSignedUrlRequest)
        {
            var client = new AmazonS3Client(_s3Option.Region);

            var putRequest = new PutObjectRequest
            {
                BucketName = _s3Option.BucketName,
                Key = _s3Option.AwsAccessKey,
                ContentBody = createSignedUrlRequest.Content
            };

            PutObjectResponse putObjectResponse = await client.PutObjectAsync(putRequest);

            GetPreSignedUrlRequest preSignedUrlRequest = new GetPreSignedUrlRequest
            {
                BucketName = _s3Option.BucketName,
                Key = _s3Option.AwsAccessKey,
                Expires = DateTime.UtcNow.AddHours(createSignedUrlRequest.TimeToLiveInHours)
            };

            return await client.GetPreSignedURLAsync(preSignedUrlRequest);
        }
    }
}
