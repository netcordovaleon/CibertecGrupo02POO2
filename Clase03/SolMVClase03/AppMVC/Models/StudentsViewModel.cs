using System.Security.Principal;

namespace AppMVC.Models
{
    public class StudentsViewModel
    {
        public StudentViewModel StudentToSave { get; set; }
        public List<StudentViewModel> StudentList { get; set; }
        public StudentsViewModel()
        {
            StudentList = new List<StudentViewModel>();
            StudentList.Add(new StudentViewModel() { Name = "Jesus Alzamora", Age = 33, Career = "Periodismo" });
            StudentList.Add(new StudentViewModel() { Name = "Fiorella Garcia", Age = 30, Career = "Educación" });
        }
    }

    public class StudentViewModel {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Career { get; set; }
    }

}
