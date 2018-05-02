using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCoursesMVC.Models;
using StudentCoursesMVC.Models.EntityModels;

namespace StudentCoursesMVC.Services
{
    //public class StudentsService : Controller
    public class StudentService : IStudentService
    {

        private EntityModel db = new EntityModel();

        public StudentService()
        {
        }

        public List<Students> GetAll()
        {

            //return View(db.Students.ToList());
            var lista =  db.Students.ToList();
            return lista;
        }

        // GET: Students/Details/5
        public Students GetSingle(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return null;
            }
            Students student = db.Students.Find(id);
            if (student == null)
            {
                //return HttpNotFound();
                return null;
            }
            return student;
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Students Create([Bind(Include = "ID,Name")] Students student)
        {
            if (student != null)
            {
                db.Students.Add(student);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return student;
        }

        // GET: Students/Edit/5
        public Students Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return null;
            }
            Students student = db.Students.Find(id);
            if (student == null)
            {
                //return HttpNotFound();
                return null;
            }
            return student;
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Students Edit([Bind(Include = "ID,Name")] Students student)
        {
            //if (ModelState.IsValid)
            if (student != null)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return student;
        }

        // GET: Students/Delete/5
        public Students Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return null;
            }
            Students student = db.Students.Find(id);
            if (student == null)
            {
                //return HttpNotFound();
                return null;
            }
            return student;
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        public void DeleteConfirmed(int id)
        {
            Students student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            //return RedirectToAction("Index");

        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}