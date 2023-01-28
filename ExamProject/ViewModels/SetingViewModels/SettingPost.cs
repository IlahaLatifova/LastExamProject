using System.ComponentModel.DataAnnotations;

namespace ExamProject.ViewModels.SetingViewModels
{
    public class SettingPost
    {
        public string IconText { get; set; }
        [DataType(DataType.Url)]
        public string? TwitterUrl { get; set; }
        [DataType(DataType.Url)]
        public string? FacebookUrl { get; set; }
        [DataType(DataType.Url)]
        public string? InstagraUrlm { get; set; }
    }
}
