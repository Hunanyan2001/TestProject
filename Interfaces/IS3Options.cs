using Amazon;

namespace WebApplication1.Interfaces
{
    public interface IS3Options
    {
       string AwsAccessKey { get; set; }
       string AwsSecretAccessKey { get; set; }
       string AwsSessionToken { get; set; }
       string BucketName { get; set; }
       RegionEndpoint Region { get; set; }
    }
}
