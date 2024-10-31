using CommAI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommAI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CommercialScript> CommercialScript { get; set; } = default!;
        public DbSet<CommercialScriptInsights> CommercialScriptInsights { get; set; } = default!;
        public DbSet<CommercialScriptEnhanced> CommercialScriptEnhanced { get; set; } = default!;
        public DbSet<CommercialScriptSuggestion> CommercialScriptSuggestion { get; set; } = default!;
    }
}
