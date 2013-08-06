using SimpleSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSearchApp.Controllers
{
    public class Student2Controller : Controller
    {
        //
        // GET: /Student2/

        public ActionResult Index()
        {
            return View(new MyDbContext().Students.ToList());
        }

        [HttpPost]
        public ActionResult Filter(string filterText) 
        {
            var students = new MyDbContext().Students.Where(p=> 
                    p.FirstName.Contains(filterText) 
                ||  p.LastName.Contains(filterText)
                ||  p.RollNo.Contains(filterText)
                ).ToList();
            return PartialView("_students", students);
        }

    }
}
