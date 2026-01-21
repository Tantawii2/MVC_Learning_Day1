using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class StudentController : Controller
    {
      /*  public IActionResult Index()
        {
            return View();
        }*/


   /*     public ViewResult Start()
        {

            //Declare
            
            ViewResult _viewResult = new ViewResult();

            //Assign 
            
            _viewResult.ViewName = "Start";

            //return

            return _viewResult;
        
        }*/



        public IActionResult GetData(int id)
        {
            if (id==1)
            {
                /*                //Declare

                                ViewResult _viewResult = new ViewResult();

                                //Assign 

                                _viewResult.ViewName = "Start";

                                //return

                                return _viewResult;

                */

                return View("GetdataPage");
            }

            else
            {
                /*              ContentResult _contentResult = new ContentResult();

                              _contentResult.Content="I'm  a Content ....   ";
                              return _contentResult;
                */
                return Content("GetdataContent");

            }


        }
    }
}
