using AudioSeller.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.CompilerServices;

namespace AudioSeller.DbConnect
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<AudioMaster> AudioMaster { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Operator> Operator { get; set; }
    }
}
