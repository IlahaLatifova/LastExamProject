using ExamProject.Models;
using ExamProject.ViewModels.PortfolioViewModels;
using ExamProject.ViewModels;
using ExamProject.ViewModels.SetingViewModels;

namespace ExamProject.ViewModels.SettingPortfolioViewModels
{
    public class SettingPortfolioVm
    {
        public List<PortfolioGetVm> portfolioGetVms { get; set; }
        public SettingGet settingGet { get; set; }
    }
}
