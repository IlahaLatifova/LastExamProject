using AutoMapper;
using ExamProject.Models;
using ExamProject.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Identity;

namespace ExamProject.Areas.manage.Services
{
    public class AccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<AppUserGet> GetAccount()
        {
            AppUser user = await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name);
            if(user is null)
            {
                return null;
            }
            AppUserGet userGet = _mapper.Map<AppUserGet>(user);
            return userGet;
        }
    }
}
