using Ajax_Crud_App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Ajax_Crud_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<StudentModel>students= new List<StudentModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            students = new List<StudentModel>();
            students.Add(new StudentModel() { Id=1,Email="Mohamed@gmail.com",Name="Mohamed"});
            students.Add(new StudentModel() { Id=2,Email="Ahmed@gmail.com",Name="Ahmed"});
            students.Add(new StudentModel() { Id=3,Email="Ali@gmail.com",Name="Ali"});
            students.Add(new StudentModel() { Id=4,Email="Omer@gmail.com",Name="Omer"});
            students.Add(new StudentModel() { Id=5,Email="Esaam@gmail.com",Name="Esaam"});
        }

        public IActionResult Index()
        {
            return View(students);
        }


        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            var student=students.Where(x=>x.Id.Equals(id)).FirstOrDefault();
            JsonResponViewModel Model = new JsonResponViewModel();
            if (student!=null)
            {
                Model.ResponseCode = 0;
                Model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                Model.ResponseCode=1;
                Model.ResponseMessage = "No Recored Availabel !";
            }
            return Json(Model);
        }






        [HttpPost]
        public JsonResult InsertStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Email = formcollection["email"];
            student.Name = formcollection["name"];

            JsonResponViewModel model = new JsonResponViewModel();
            //MAKE DB CALL and handle the response ==>Save TO database ==>>>
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }


        [HttpPut]
        public JsonResult UpdateStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formcollection["id"]);
            student.Email = formcollection["email"];
            student.Name = formcollection["name"];

            JsonResponViewModel model = new JsonResponViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }





        [HttpDelete]
        public JsonResult DeleteStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formcollection["id"]);

            JsonResponViewModel model = new JsonResponViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}