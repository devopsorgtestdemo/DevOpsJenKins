using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppMVCDemo.Models;

namespace WebAppMVCDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {

            Student student = new Student()
            {
                Id=1001,
                Name="Raj",
                Address="Hyd",
                Email="XYZ@.com",
                Mobile="8819969809"
            };


            List<Student> data = new List<Student>();
            data.Add(student);
            Dictionary<Student,List<Student>> dis = new Dictionary<Student,List<Student>>();
            dis.Add(student, data);

            return View(dis);
        }
    }
}
