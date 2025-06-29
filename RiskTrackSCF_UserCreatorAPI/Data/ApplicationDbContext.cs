using RiskTrackSCF_UserCreatorAPI.Models.UserCreatorApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace RiskTrackSCF_UserCreatorAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     
        }
    }
}
