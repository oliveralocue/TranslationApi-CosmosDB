using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TranslationApi.Models
{
    public class TranslationContext : DbContext
    {
        public TranslationContext(DbContextOptions<TranslationContext> options)
            : base(options)
        {
        }
        public DbSet<TranslationItem> TranslationItems { get; set; }
    }
}
