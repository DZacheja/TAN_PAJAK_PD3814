using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UczelniaAPI.Models;
public class Student
{
    public int IdStudent { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string NrIndeksu { get; set; }
    public int RokStudiow { get; set; }
    public virtual int IdStudia { get; set; }
    public virtual Studia Studia { get; set; }
}
