using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductionGradeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get All Student");
        }

        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok("Get This " + code + " Department Data");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("Insert New Department");
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code)
        {
            return Ok("Update This " + code + " Department Data");
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok("Delete This " + code + " Department Data");
        }
    }
}
