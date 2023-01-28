using System.ComponentModel.DataAnnotations;

namespace ExamProject.ViewModels.AppUserViewModels
{
    public class AppUserGet
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
