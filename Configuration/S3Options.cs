using Amazon;

using WebApplication1.Interfaces;

namespace WebApplication1.Configuration
{
    public class S3Options : IS3Options
    {
        public string AwsAccessKey { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string AwsSessionToken { get; set; }
        public string BucketName { get; set; }
        public RegionEndpoint Region {get; set; }
    }
}
