﻿namespace WebApplication1.Models
{
    public class CreateSignedUrlRequest
    {
        public string Content { get; set; }

        public double TimeToLiveInHours { get; set; }
    }
}
