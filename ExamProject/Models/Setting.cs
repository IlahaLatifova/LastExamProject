using System.ComponentModel.DataAnnotations;

namespace ExamProject.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string IconText { get; set; }
        [DataType(DataType.Url)]
        public string? TwitterUrl { get; set; }
        [DataType(DataType.Url)]
        public string? FacebookUrl { get; set; }
        [DataType(DataType.Url)]
        public string? InstagraUrlm { get; set; }
    }
}
