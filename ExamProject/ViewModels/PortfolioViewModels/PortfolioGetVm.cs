using System.ComponentModel.DataAnnotations;

namespace ExamProject.ViewModels.PortfolioViewModels
{
    public class PortfolioGetVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
