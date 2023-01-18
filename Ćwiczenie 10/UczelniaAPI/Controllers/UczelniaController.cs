using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UczelniaAPI.Services.Interafces;

namespace UczelniaAPI.Controllers;
[Route("api/uczelnia")]
[ApiController]
public class UczelniaController : ControllerBase
{
    private IDatabaseService _service;

    public UczelniaController(IDatabaseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _service.GetStudents();
        if(students == null)
        {
            return NotFound();
        } else
        {
            return Ok(students);
        }
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudent([FromRoute] int studentId)
    {
        var student = await _service.GetStudent(studentId);
        if(student == null)
        {
            return NotFound();
        } else
        {
            return Ok(student);
        }
    }
}
