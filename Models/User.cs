﻿namespace TestProject.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }    

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? NickName { get; set; }

        public ICollection<UserFile>? Files { get; set; }
    }
}
