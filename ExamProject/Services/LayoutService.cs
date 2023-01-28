using AutoMapper;
using ExamProject.DAL;
using ExamProject.Models;
using ExamProject.ViewModels.PortfolioViewModels;
using ExamProject.ViewModels.SetingViewModels;
using ExamProject.ViewModels.SettingPortfolioViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LayoutService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SettingPortfolioVm> GetService()
        {
            List<Portfolio> portfolios = await _context.Portfolios.Where(p => !p.IsDeleted).ToListAsync();
            Setting setting = _context.Setting.FirstOrDefault();
            SettingPortfolioVm service = new SettingPortfolioVm()
            {
                portfolioGetVms = _mapper.Map<List<PortfolioGetVm>>(portfolios),
                settingGet = _mapper.Map<SettingGet>(setting)
            };
            return service;
        }
}
}
