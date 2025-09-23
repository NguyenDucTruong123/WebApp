namespace WebApp.Models
{
    public class StudentForm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public IFormFile? Avatar { get; set; }
        public Branch? Branch { get; set; }
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }
        public DateTime DateOfBorth { get; set; }
        public string? Address { get; set; }
    }
}
