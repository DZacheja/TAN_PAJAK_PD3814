using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UczelniaAPI.Models;

namespace UczelniaAPI.EfConfigurations;
public class StudiaEntityConfiguration : IEntityTypeConfiguration<Studia>
{
    public void Configure(EntityTypeBuilder<Studia> builder)
    {
        builder.HasKey(s => s.IdStudia);
        builder.Property(s => s.Tryb).HasMaxLength(200).IsRequired();
        builder.Property(s => s.Nazwa).HasMaxLength(200).IsRequired();

        builder.HasData(
        new Studia { IdStudia = 1, Nazwa = "Informatyka", Tryb = "Stacjonarny" },
        new Studia { IdStudia = 2, Nazwa = "Ekonomia", Tryb = "Niestacjonarny" },
        new Studia { IdStudia = 3, Nazwa = "Zarządzanie", Tryb = "Stacjonarny" },
        new Studia { IdStudia = 4, Nazwa = "Prawo", Tryb = "Niestacjonarny" },
        new Studia { IdStudia = 5, Nazwa = "Architektura", Tryb = "Stacjonarny" },
        new Studia { IdStudia = 6, Nazwa = "Mechanika", Tryb = "Niestacjonarny" },
        new Studia { IdStudia = 7, Nazwa = "Fizyka", Tryb = "Stacjonarny" },
        new Studia { IdStudia = 8, Nazwa = "Matematyka", Tryb = "Niestacjonarny" },
        new Studia { IdStudia = 9, Nazwa = "Chemia", Tryb = "Stacjonarny" },
        new Studia { IdStudia = 10, Nazwa = "Biologia", Tryb = "Niestacjonarny" });
    }
}
