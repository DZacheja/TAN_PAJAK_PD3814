using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UczelniaAPI.Models;

namespace UczelniaAPI.EfConfigurations;
public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.IdStudent);
        builder.Property(s => s.Imie).HasMaxLength(200).IsRequired();
        builder.Property(s => s.Nazwisko).HasMaxLength(200).IsRequired();
        builder.Property(s => s.NrIndeksu).HasMaxLength(100).IsRequired();
        builder.Property(s => s.RokStudiow).IsRequired();

        builder.HasOne(s => s.Studia)
            .WithMany(s => s.Studenci)
            .HasForeignKey(s => s.IdStudia);

        builder.HasData(
       new Student { IdStudent = 1, Imie = "Anna", Nazwisko = "Kowalska", NrIndeksu = "A001", RokStudiow = 3, IdStudia = 1 },
       new Student { IdStudent = 2, Imie = "Jan", Nazwisko = "Nowak", NrIndeksu = "A002", RokStudiow = 2, IdStudia = 1 },
       new Student { IdStudent = 3, Imie = "Katarzyna", Nazwisko = "Wiśniewska", NrIndeksu = "A003", RokStudiow = 4, IdStudia = 2 },
       new Student { IdStudent = 4, Imie = "Piotr", Nazwisko = "Wojtyła", NrIndeksu = "A004", RokStudiow = 1, IdStudia = 2 },
       new Student { IdStudent = 5, Imie = "Agnieszka", Nazwisko = "Kowalczyk", NrIndeksu = "A005", RokStudiow = 3, IdStudia = 3 },
       new Student { IdStudent = 6, Imie = "Adam", Nazwisko = "Majewski", NrIndeksu = "A006", RokStudiow = 2, IdStudia = 3 },
       new Student { IdStudent = 7, Imie = "Ewa", Nazwisko = "Kozłowska", NrIndeksu = "A007", RokStudiow = 4, IdStudia = 4 },
       new Student { IdStudent = 8, Imie = "Tomasz", Nazwisko = "Jabłoński", NrIndeksu = "A008", RokStudiow = 1, IdStudia = 4 },
       new Student { IdStudent = 9, Imie = "Magdalena", Nazwisko = "Wróbel", NrIndeksu = "A009", RokStudiow = 3, IdStudia = 5 },
       new Student { IdStudent = 10, Imie = "Dariusz", Nazwisko = "Kaczmarek", NrIndeksu = "A010", RokStudiow = 2, IdStudia = 5 },
       new Student { IdStudent = 11, Imie = "Adam", Nazwisko = "Szczepanowski", NrIndeksu = "A011", RokStudiow = 1, IdStudia = 5 },
       new Student { IdStudent = 12, Imie = "Ewa", Nazwisko = "Kowalska", NrIndeksu = "A012", RokStudiow = 2, IdStudia = 7 },
       new Student { IdStudent = 13, Imie = "Jan", Nazwisko = "Nowak", NrIndeksu = "A013", RokStudiow = 3, IdStudia = 7 },
       new Student { IdStudent = 14, Imie = "Anna", Nazwisko = "Kowalska", NrIndeksu = "A014", RokStudiow = 4, IdStudia = 7 },
       new Student { IdStudent = 15, Imie = "Katarzyna", Nazwisko = "Wiśniewska", NrIndeksu = "A015", RokStudiow = 5, IdStudia = 8 },
       new Student { IdStudent = 16, Imie = "Piotr", Nazwisko = "Wojtyła", NrIndeksu = "A016", RokStudiow = 1, IdStudia = 9 },
       new Student { IdStudent = 17, Imie = "Agnieszka", Nazwisko = "Kowalczyk", NrIndeksu = "A017", RokStudiow = 2, IdStudia = 9 },
       new Student { IdStudent = 18, Imie = "Adam", Nazwisko = "Majewski", NrIndeksu = "A018", RokStudiow = 3, IdStudia = 9 },
       new Student { IdStudent = 19, Imie = "Ewa", Nazwisko = "Kozłowska", NrIndeksu = "A019", RokStudiow = 4, IdStudia = 10 },
       new Student { IdStudent = 20, Imie = "Tomasz", Nazwisko = "Jabłoński", NrIndeksu = "A020", RokStudiow = 5, IdStudia = 10 });
    }
}
