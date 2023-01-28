using System.ComponentModel.DataAnnotations;

namespace ExamProject.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
