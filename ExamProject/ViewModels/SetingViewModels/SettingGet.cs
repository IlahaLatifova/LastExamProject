using System.ComponentModel.DataAnnotations;

namespace ExamProject.ViewModels.SetingViewModels
{
    public class SettingGet
    {
        public int Id { get; set; }
        public string IconText { get; set; }
        public string? TwitterUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagraUrlm { get; set; }
    }
}
