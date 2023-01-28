using System.ComponentModel.DataAnnotations;

namespace ExamProject.ViewModels.PortfolioViewModels
{
    public class PortfolioPostVm
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public string Type { get; set; }
        public string Description { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
