using AutoMapper;
using ExamProject.DAL;
using ExamProject.Models;
using ExamProject.ViewModels.PortfolioViewModels;
using ExamProject.ViewModels.SetingViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ExamProject.Areas.manage.Controllers
{
    [Area("manage"), Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SettingController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Setting setting = _context.Setting.FirstOrDefault();
            if(setting is null)
            {
                return NotFound();
            }
            SettingGet settingGet  = _mapper.Map<SettingGet>(setting);
            return View(settingGet);
        }
        public async Task<IActionResult> Update(int id)
        {
            Setting setting = _context.Setting.Find(id);
            if (setting is null)
            {
                return NotFound();
            }
            SettingUpdate settingUpdate = new SettingUpdate()
            {
                SettingGet = _mapper.Map<SettingGet>(setting)
            };
            return View(settingUpdate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SettingUpdate settingUpdate)
        {
            Setting setting = _context.Setting.FirstOrDefault(p => p.Id == settingUpdate.SettingGet.Id);
            if (setting is null)
            {
                return NotFound();
            }
            setting.IconText = settingUpdate.SettingPost.IconText;
            setting.InstagraUrlm = settingUpdate.SettingPost.InstagraUrlm;
            setting.FacebookUrl = settingUpdate.SettingPost.FacebookUrl;
            setting.TwitterUrl = settingUpdate.SettingPost.TwitterUrl;
            _context.Setting.Update(setting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
