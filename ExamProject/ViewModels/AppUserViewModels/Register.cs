using System.ComponentModel.DataAnnotations;

namespace ExamProject.ViewModels.AppUserViewModels
{
    public class Register
    {
        [Required,StringLength(maximumLength:100)]
        public string UserName { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string FullName { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,StringLength(maximumLength:20),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, StringLength(maximumLength: 20), DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
