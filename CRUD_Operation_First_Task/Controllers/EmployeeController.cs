using CRUD_Operation_First_Task.DAl.DataBase;
using CRUD_Operation_First_Task.DAl.Entities;
using CRUD_Operation_First_Task.DAl.DataBase;

using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation_First_Task.Controllers
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
            var EmployeeList = _Db_Context.employees.ToList();


            return View(EmployeeList);
        }

        public IActionResult Create()
        {

            return View();


        }

        public IActionResult SaveCreateData(Employee NewEmployee)
        {
    

            if (NewEmployee.Name == "" || NewEmployee.Salary == 0 )
            {
                return RedirectToAction("Create"); 


            }
            // Maping 
         
            var MappEmployee = new Employee { Name = NewEmployee.Name , Salary = NewEmployee.Salary};
            //add
            var result = _Db_Context.employees.Add(MappEmployee);

            _Db_Context.SaveChanges();
            return RedirectToAction("index", "Employee");

        }




        public IActionResult Edit(int id)
        {

            var Employee= _Db_Context.employees.Where(a=>a.Id== id).FirstOrDefault();
            return View(Employee);


        }

        public IActionResult SaveEditData(Employee NewEmployee,int  id)
        {
            if (NewEmployee.Name == "" || NewEmployee.Salary == 0)
            {
                return RedirectToAction("Edit");


            }

            var Oldemployee = _Db_Context.employees.Where(a => a.Id == id).FirstOrDefault();
            Oldemployee.Name= NewEmployee.Name;
            Oldemployee.Salary= NewEmployee.Salary;
            _Db_Context.SaveChanges();
            return RedirectToAction("index", "Employee");


        }



        public IActionResult Delete(int id)
        {


            var Employee = _Db_Context.employees.Where(a => a.Id == id).FirstOrDefault();
            _Db_Context.Remove(Employee);
            _Db_Context.SaveChanges();
            return RedirectToAction("index", "Employee");
        }

        public IActionResult Details(int id)
        {

            var Employee = _Db_Context.employees.Where(a => a.Id == id).FirstOrDefault();


            return View(Employee);
        }





    }
}
