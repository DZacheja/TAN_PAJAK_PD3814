using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UczelniaAPI.Models;

namespace UczelniaAPI.Services.Interafces;
public interface IDatabaseService
{
    public Task<Student> GetStudent(int id);
    public Task<List<Student>> GetStudents();
}
