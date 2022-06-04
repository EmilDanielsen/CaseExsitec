using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CaseExsitec.Models;

namespace CaseExsitec.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CaseExsitec.Models.InnOgUtleveranse>? InnOgUtleveranse { get; set; }
        public DbSet<CaseExsitec.Models.Produkter>? Produkter { get; set; }
    }
}