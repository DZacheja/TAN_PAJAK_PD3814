using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using StudentsAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace StudentsAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly string DATABASE_PATH = @"Data\database.json";
        private static List<Student> _students;
        public StudentsController()
        {

            using (StreamReader sr = new StreamReader(@"Data\database.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                _students = (List<Student>)serializer.Deserialize(sr, typeof(List<Student>));
                if (_students == null)
                {
                    _students = new List<Student>();
                }
            }
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_students);
        }

        [HttpGet("{studentId}")]
        public IActionResult GetStudent(int studentId)
        {
            var s = _students.FirstOrDefault(x => x.StudentId == studentId);
            if(s != null)
            {
                return Ok(s);
            } else
            {
                return NotFound("Osoba o podanym numerze ID nie istnieje w bazie.");
            }
        }
        
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            string msg = "";
            if (validData(student, ref msg))
            {
                _students.Add(student);
                SaveStudents();
                return Ok(student);
            } else
            {
                return UnprocessableEntity(msg);
            }
        }

        [HttpPatch("{studentId}")]
        public IActionResult UpdateStudent([FromBody] Student student, [FromRoute] int studentId)
        {
            var s = _students.FirstOrDefault(x => x.StudentId == studentId);
            if (s == null)
            {
                return NotFound("Osoba o podanym numerze ID nie istnieje w bazie.");
            } else
            {
                int idx = _students.IndexOf(s);
                _students[idx] = student;
                SaveStudents();
                return Ok(s);
            }
        }

        [HttpDelete("{studentId}")]
        public IActionResult DeleteStudent([FromRoute] int studentId)
        {
            var s = _students.FirstOrDefault(x => x.StudentId == studentId);
            if (s == null)
            {
                return NotFound("Osoba o podanym numerze ID nie istnieje w bazie.");
            } else
            {
                _students.Remove(s);
                SaveStudents();
                return NoContent();
            }
        }

        private void SaveStudents()
        {
            // serialize JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(DATABASE_PATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _students);
            }
        }

        private bool validData(Student s, ref string msg)
        {
            if (s.StudentId == 0 || string.IsNullOrEmpty(s.FirstName) || string.IsNullOrEmpty(s.LastName) || string.IsNullOrEmpty(s.IndexNumber))
            {
                msg = "Wprowadzono puste dane!";
                return false;
            }

            if (!s.Email.Contains('@') || !s.Email.Contains('.'))
            {
                msg = "Podany e-mail jest nieprawidłowy!";
                return false;
            }

            if (_students.FirstOrDefault(x => x.StudentId == s.StudentId) != null)
            {
                msg = "Student o podanym ID już istnieje!";
                return false;
            }

            if (_students.FirstOrDefault(x => x.IndexNumber == s.IndexNumber) != null)
            {
                msg = "Student o podanym numerze indeksu już isnieje!";
                return false;
            }

            return true;
        }

    }
}
