using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DLL.Models;
using System.Collections.Generic;
using System.Linq;
using DLL.Repositories;
using System.Threading.Tasks;
using BLL.Services;
using BLL.Request;

namespace ProductionGradeAPI.Controllers
{
    
    public class DepartmentController : MainAPIController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

    // Implement REST API with Basic Response   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Ok("Get All Department");
            //return Ok(DepartmentStatic.GetAllDepartment());
            //return Ok(await _departmentRepository.GetAllAsync());
            return Ok(await _departmentService.GetAllAsync());
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            //return Ok("Get This " + code + " Department Data");
            //return Ok(DepartmentStatic.GEtADepartment(code));
            return Ok(await _departmentService.GetAAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(DepartmentInsertRequestViewModel request)
        {
            //return Ok("Insert New Department");
            //return Ok(DepartmentStatic.InsertDepartment(department));
            return Ok(await _departmentService.InsertAsync(request));
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, Department department)
        {
            //return Ok("Update This " + code + " Department Data");
            //return Ok(DepartmentStatic.UpdateDepartment(code, department));
            return Ok(await _departmentService.UpdateAsync(code, department));
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            //return Ok("Delete This " + code + " Department Data");
            //return Ok(DepartmentStatic.DeleteDepartment(code));
            return Ok(await _departmentService.DeleteAsync(code));
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
