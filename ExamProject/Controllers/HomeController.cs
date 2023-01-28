using AutoMapper;
using ExamProject.DAL;
using ExamProject.Models;
using ExamProject.ViewModels.PortfolioViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExamProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Portfolio> portfolios = await _context.Portfolios.Where(p => !p.IsDeleted).ToListAsync();
            List<PortfolioGetVm> portfoliosGet = _mapper.Map<List<PortfolioGetVm>>(portfolios);
            return View(portfoliosGet);
        }

        
    }
}