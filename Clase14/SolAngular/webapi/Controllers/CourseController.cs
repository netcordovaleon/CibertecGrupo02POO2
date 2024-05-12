using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Course> GetAllCourses() {
            IList<Course> course = new  List<Course>();
            course.Add(new Course { 
                Id = 1,
                Name = "Test"
            });
            return course;
        }

    }


    public class Course {

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
