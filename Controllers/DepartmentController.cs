using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductionGradeAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductionGradeAPI.Controllers
{
    
    public class DepartmentController : MainAPIController
    {
    // Implement REST API with Basic Response   
        [HttpGet]
        public IActionResult GetAll()
        {
            //return Ok("Get All Department");
            return Ok(DepartmentStatic.GetAllDepartment());
        }

        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            //return Ok("Get This " + code + " Department Data");
            return Ok(DepartmentStatic.GEtADepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            //return Ok("Insert New Department");
            return Ok(DepartmentStatic.InsertDepartment(department));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, Department department)
        {
            //return Ok("Update This " + code + " Department Data");
            return Ok(DepartmentStatic.UpdateDepartment(code, department));
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            //return Ok("Delete This " + code + " Department Data");
            return Ok(DepartmentStatic.DeleteDepartment(code));
        }
       
    }

    public static class DepartmentStatic
    {
        private static List<Department> AllDepartment { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            AllDepartment.Add(department);
            return department;
        }

        public static List<Department> GetAllDepartment()
        {
            return AllDepartment;
        }

        public static Department GEtADepartment(string code)
        {
            return AllDepartment.FirstOrDefault(x => x.Code == code);
        }

        public static Department UpdateDepartment(string code, Department department)
        {
            Department result = new Department();

            foreach (var aDepartment in AllDepartment)
            {
                if (code == aDepartment.Code)
                {
                    aDepartment.Name = department.Name;
                    result = aDepartment;
                }
            }
            return result;
        }

        public static Department DeleteDepartment(string code)
        {
            var department = AllDepartment.FirstOrDefault(x => x.Code == code);
            AllDepartment = AllDepartment.Where(x => x.Code != department.Code).ToList();
            return department;
        }

    }


}
