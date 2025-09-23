using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class StudentForm
    {
        public int Id { get; set; }
        [StringLength(100 , MinimumLength = 4 , ErrorMessage ="Độ dài tên không hợp lệ phải lớn hơn 4 ký tự")]
        [Required]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(
        @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$",
        ErrorMessage = "Email không hợp lệ"
        )]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt"
        )]
        public string? Password { get; set; }

        public IFormFile? Avatar { get; set; }
        [Required]
        public Branch? Branch { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }
        [Range(typeof(DateTime),"1/1/1963","12/31/2024")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBorth { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string? Address { get; set; }
    }
}
