using Microsoft.EntityFrameworkCore;
using CC_Regist_System.Models;


namespace razorproject.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LoginDetail> LoginDetails { get; set; } = null!;
        public DbSet<UserDetails> UserDetails { get; set; } = null!;
        public DbSet<ApplyCardViewModel> ApplyCardViewModels { get; set; } = null!;
        public DbSet<CardDetails> CardDetails { get; set; }

    }
}