using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UczelniaAPI.Models;
using UczelniaAPI.Services.Interafces;

namespace UczelniaAPI.Services;
public class SqlServerService : IDatabaseService
{
    private UczelniaContext _context;
    public SqlServerService(UczelniaContext context)
    {
        _context = context;
    }

    public async  Task<Student> GetStudent(int id)
    {
        return await _context.Students
            .Include(s => s.Studia)
            .FirstOrDefaultAsync(s => s.IdStudent == id);
    }

    public async Task<List<Student>> GetStudents()
    {
        return _context.Students.Include(s => s.Studia).ToList();
    }
}
