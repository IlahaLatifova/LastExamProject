using ExamProject.Models;
using ExamProject.ViewModels.SetingViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Setting> Setting { get; set; }
    }
}
