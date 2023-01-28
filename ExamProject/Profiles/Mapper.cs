using AutoMapper;
using ExamProject.Models;
using ExamProject.ViewModels.AppUserViewModels;
using ExamProject.ViewModels.PortfolioViewModels;
using ExamProject.ViewModels.SetingViewModels;

namespace ExamProject.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Portfolio, PortfolioGetVm>();
            CreateMap<PortfolioPostVm, Portfolio>();
            CreateMap<Setting, SettingGet>();
            CreateMap<SettingPost, Setting>();
            CreateMap<AppUser, AppUserGet>();
        }
    }
}
