using Day3.Dal.DataBase;
using Day3.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
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


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SaveData(string Name , double Salary)
         {

            //Map Data 
            var mappNewEmployee = new Employee()
            {
                Name=Name,
                Salary=Salary
            };

         //Add In DataBAse
             var result = _Db_Context.employees.Add(mappNewEmployee);
            //Save Data
            _Db_Context.SaveChanges();          
             return RedirectToAction("index","Employee");
    

        }

        public IActionResult Edit(int id)
        {
            var mappEditEmployee= _Db_Context.employees.Where(a=>a.Id==id).FirstOrDefault();
            return View(mappEditEmployee);
        }

        public IActionResult SaveEditData(string Name, double Salary,int Id)
        {

            var OldEmployee = _Db_Context.employees.Where(a=>a.Id == Id).FirstOrDefault();  
            
            OldEmployee.Name=Name;
             OldEmployee.Salary=Salary;  

            //Save Data
            _Db_Context.SaveChanges();
            return RedirectToAction("index", "Employee");


        }
    }
}
