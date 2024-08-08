namespace TestProject.Models
{
    public class UserFile
    {
        public Guid Id { get; set; }

        public string? Url { get; set; }

        public string? Name { get; set; }

        public string? Path { get; set; }

        public string? Size { get; set; }
        
        public string? Content { get; set; }    

        public Guid? UserId { get; set; }   

        public User? User { get; set; }  
    }
}
