using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DLL.Models;
using System.Collections.Generic;
using System.Linq;
using DLL.Repositories;
using System.Threading.Tasks;
using BLL.Services;

namespace ProductionGradeAPI.Controllers
{
    
    public class StudentController : MainAPIController
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Implement REST API with Basic Response   
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string rollNumber, [FromQuery] string nickName)
        {
            //return Ok("Get All Student");
            //return Ok(StudentStatic.GetAllStudent());
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetA(string email)
        {
            //return Ok("Get This " + code + " Student Data");
            //return Ok(StudentStatic.GEtAStudent(email));
            return Ok(await _studentService.GetAAsync(email));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Student student)
        {
            //return Ok("Insert New Student");
            //return Ok(StudentStatic.InsertStudent(student));
            return Ok(await _studentService.InsertAsync(student));
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> Update(string email,/*[FromForm]*/ Student student)
        {
            //return Ok("Update This " + code + " Student Data");
            //return Ok(StudentStatic.UpdateStudent(email, student));
            return Ok(await _studentService.UpdateAsync(email, student));
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            //return Ok("Delete This " + code + " Student Data");
            //return Ok(StudentStatic.DeleteStudent(email));
            return Ok(await _studentService.DeleteAsync(email));
        }

    }

    public static class StudentStatic
    {
        private static List<Student> AllStudent { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            AllStudent.Add(student);
            return student;
        }

        public static List<Student> GetAllStudent()
        {
            return AllStudent;
        }

        public static Student GEtAStudent(string email)
        {
            return AllStudent.FirstOrDefault(x => x.Email == email);
        }

        public static Student UpdateStudent(string email, Student student)
        {
            Student result = new Student();

            foreach (var aStudent in AllStudent)
            {
                if (email == aStudent.Email)
                {
                    aStudent.Name = student.Name;
                    result = aStudent;
                }
            }
            return result;
        }

        public static Student DeleteStudent(string email)
        {
            var student = AllStudent.FirstOrDefault(x => x.Email == email);
            AllStudent = AllStudent.Where(x => x.Email != student.Email).ToList();
            return student;
        }

    }


}
