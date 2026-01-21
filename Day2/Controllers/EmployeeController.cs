using Day2.Dal.DataBase;
using Day2.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _Db_Context;

       public EmployeeController()
        {
            _Db_Context = new ApplicationDbContext();

        }
        public IActionResult Index()
        {
            var  result = _Db_Context.employees.ToList();
            return View(result);
        }


        public IActionResult GetEmployeeByID(int id)
        {

            var result = _Db_Context.employees.
                Where(a => a.Id == id).FirstOrDefault();       
        
            return View(result);
        
        
        }


     
    }
}
