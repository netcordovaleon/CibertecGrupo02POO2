using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet]
        public IActionResult HolaMundo() {

            return Ok(new { mensaje = "Hola Mundo desde .NET", tipoFormato= "JSON"  });
        }

        [HttpGet]
        [Route("msg2")]
        public string HolaMundo2()
        {

            return "Hola Mundo desde .NET";
        }


        [HttpGet]
        [Route("msg3")]
        public string HolaMundo3()
        {

            return "Hola Mundo desde .NET";
        }


    }
}
