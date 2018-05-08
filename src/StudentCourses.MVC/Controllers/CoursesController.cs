﻿using System.Web.Mvc;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.MVC.Controllers
{
    /// <summary>
    /// The Course Controller class.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class CoursesController : Controller
    {
        /// <summary>
        /// The course service instance.
        /// </summary>
        private IRepositoryService<Course> courseService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesController"/> class.
        /// Using Unity Dependency Injection.
        /// </summary>
        /// <param name="courseService">The course service.</param>
        public CoursesController(IRepositoryService<Course> courseService)
        {
            this.courseService = courseService;
        }

        /// GET: Courses
        public ActionResult Index()
        {
            return View(courseService.GetAll());
        }

        /// GET: Courses/Details/Id
        public ActionResult Details(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Course course = courseService.Details(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        /// GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        /// POST: Courses/Create
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseService.Add(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        /// GET: Courses/Edit/Id
        public ActionResult Edit(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Course course = courseService.ToEdit(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        /// POST: Courses/Edit/Id
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseService.Edit(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        /// GET: Courses/Delete/Id
        public ActionResult Delete(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Course course = courseService.ToDelete(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        /// POST: Courses/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            courseService.DeleteConfirmed(Id);
            return RedirectToAction("Index");
        }

    }
}
