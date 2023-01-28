using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamProject.DAL;
using ExamProject.Models;
using AutoMapper;
using ExamProject.ViewModels.PortfolioViewModels;
using ExamProject.Areas.manage.ViewModels;
using ExamProject.Extensions.FileManagmentExtensions;
using Microsoft.AspNetCore.Authorization;

namespace ExamProject.Areas.manage.Controllers
{
    [Area("manage"),Authorize(Roles ="Admin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public PortfolioController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IActionResult> Index(int currentPage = 1, int take = 3)
        {
            List<Portfolio> portfolios = await _context.Portfolios
                .OrderByDescending(x=>x.Id)
                .Skip((currentPage-1)*take)
                .Take(take)
                .ToListAsync();
            List<PortfolioGetVm> portfoliosGetVm = _mapper.Map<List<PortfolioGetVm>>(portfolios);
            int totalCount = await GetPageCount(take);
            PaginationVm<PortfolioGetVm> pagination = new PaginationVm<PortfolioGetVm>()
            {
                CurrentPage = currentPage,
                Models = portfoliosGetVm,
                TotalPageCount = totalCount,
                Previous = currentPage > 1,
                Next = currentPage < totalCount

            };
              return View(pagination);
        }

        private async Task<int> GetPageCount(int take)
        {
            int modelCount = await _context.Portfolios.CountAsync();
            int totalCount = (int)Math.Ceiling((decimal)modelCount / take);
            return totalCount;
        }
         
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioPostVm portfolioPost)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolioPost);
            }
            Portfolio newPortfolio = _mapper.Map<Portfolio>(portfolioPost);
            if(portfolioPost.FormFile is not null)
            {
                if (!portfolioPost.FormFile.IsTrueContent())
                {
                    ModelState.AddModelError("FormFile", "Invalid Format!!!");
                    return View(portfolioPost);
                }
                if (!portfolioPost.FormFile.IsValidLength())
                {
                    ModelState.AddModelError("FormFile", "Length must be less than 2mb!!!");
                    return View(portfolioPost);
                }
                newPortfolio.ImageUrl = portfolioPost.FormFile.CreateUrl(_env.WebRootPath, "assets/img/portfolio");
            }
            await _context.Portfolios.AddAsync(newPortfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Portfolio portfolio = _context.Portfolios.Find(id);
            if(portfolio is null)
            {
                return NotFound();
            }
            PortfolioUpdateVm portfolioUpdate = new PortfolioUpdateVm()
            {
                portfolioGet = _mapper.Map<PortfolioGetVm>(portfolio)
            };
            return View(portfolioUpdate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PortfolioUpdateVm portfolioUpdate)
        {
            Portfolio portfolio = _context.Portfolios.FirstOrDefault(p=>p.Id==portfolioUpdate.portfolioGet.Id);
            if (portfolio is null)
            {
                return NotFound();
            }
            portfolio.Name = portfolioUpdate.portfolioPost.Name;
            portfolio.Description = portfolioUpdate.portfolioPost.Description;
            if (portfolioUpdate.portfolioPost.FormFile is not null)
            {
                if (!portfolioUpdate.portfolioPost.FormFile.IsTrueContent())
                {
                    ModelState.AddModelError("FormFile", "Invalid Format!!!");
                    return View(portfolioUpdate);
                }
                if (!portfolioUpdate.portfolioPost.FormFile.IsValidLength())
                {
                    ModelState.AddModelError("FormFile", "Length must be less than 2mb!!!");
                    return View(portfolioUpdate);
                }
                portfolio.ImageUrl.DeleteFile(_env.WebRootPath, "assets/img/portfolio");
                portfolio.ImageUrl = portfolioUpdate.portfolioPost.FormFile.CreateUrl(_env.WebRootPath, "assets/img/portfolio");
            }
            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SoftDelete(int id)
        {
            Portfolio portfolio = _context.Portfolios.Find(id);
            if (portfolio is null)
            {
                return NotFound();
            }
            if (!portfolio.IsDeleted)
            {
                portfolio.IsDeleted = true;
            }
            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Restore(int id)
        {
            Portfolio portfolio = _context.Portfolios.Find(id);
            if (portfolio is null)
            {
                return NotFound();
            }
            if (portfolio.IsDeleted)
            {
                portfolio.IsDeleted = false;
            }
            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> HardDelete(int id)
        {
            Portfolio portfolio = _context.Portfolios.Find(id);
            if (portfolio is null)
            {
                return NotFound();
            }
            _context.Portfolios.Remove(portfolio);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
