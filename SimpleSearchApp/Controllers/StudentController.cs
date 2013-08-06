using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSearchApp.Models;

namespace SimpleSearchApp.Controllers
{
    public class StudentController : Controller
    {
        private MyDbContext db = new MyDbContext();

        //
        // GET: /Student/

        public ActionResult Index()
        {

            ViewBag.SearchParameters = new SelectList(db.Parameters.ToList(), "ParameterName", "ParameterName");
            return View(db.Students.ToList());
        }


        [HttpPost]
        public ActionResult Filter(FormCollection formCollection) 
        {

            var students = new List<Student>();
            var filterBy = formCollection.Get("SearchParameters");
            var filterText = formCollection.Get("txtFilter");

            switch (filterBy) 
            {
                case "FirstName":
                    students = db.Students.Where(p => p.FirstName.Contains(filterText)).ToList();
                    break;
                case "LastName":
                    students = db.Students.Where(p => p.LastName.Contains(filterText)).ToList();
                    break;
            }


            ViewBag.SearchParameters = new SelectList(db.Parameters.ToList(), "ParameterName", "ParameterName");
            return View("Index",students);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}