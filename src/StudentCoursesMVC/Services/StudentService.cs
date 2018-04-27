using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCoursesMVC.Models;

namespace StudentCoursesMVC.Services
{
    //public class StudentsService : Controller
    public class StudentService : IStudentService
    {

        private StudentDBContext db = new StudentDBContext();

        public StudentService()
        {
        }

        public List<Student> GetAll()
        {
            //return View(db.Students.ToList());
            return db.Students.ToList();
        }

        // GET: Students/Details/5
        public Student GetSingle(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return null;
            }
            Student student = db.Students.Find(id);
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
        public Student Create([Bind(Include = "ID,Name")] Student student)
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
        public Student Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return null;
            }
            Student student = db.Students.Find(id);
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
        public Student Edit([Bind(Include = "ID,Name")] Student student)
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
        public Student Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return null;
            }
            Student student = db.Students.Find(id);
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
            Student student = db.Students.Find(id);
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