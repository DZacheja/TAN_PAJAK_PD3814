using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UczelniaAPI.Models;
public class Studia
{
    public int IdStudia { get; set; }
    public string Nazwa { get; set; }
    public string Tryb { get; set; }

    public virtual ICollection<Student> Studenci {get; set; }   

}
