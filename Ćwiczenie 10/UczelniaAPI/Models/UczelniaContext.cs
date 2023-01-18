using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UczelniaAPI.EfConfigurations;

namespace UczelniaAPI.Models;
public class UczelniaContext: DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Studia> Studies { get; set; }

    public UczelniaContext(DbContextOptions options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StudiaEntityConfiguration());
    }

}
