using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContexts;

namespace StudentCourses.MVC.Controllers
{
    /// <summary>
    /// THe Registration Controller class
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class RegistrationsController : Controller
    {
        /// <summary>
        /// The registration service instance
        /// </summary>
        private IRepositoryService<Registration> registrationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationsController"/> class.
        /// Using Unity Dependency Injection
        /// </summary>
        /// <param name="registrationService">The registration service.</param>
        public RegistrationsController(IRepositoryService<Registration> registrationService)
        {
            this.registrationService = registrationService;
        }

        /// GET: Registrations
        public ActionResult Index()
        {
            return View(registrationService.GetAll());
        }

        /// GET: Registrations/Details/5
        public ActionResult Details(int Id)
        {
            Registration registration = registrationService.Details(Id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        /// GET: Registrations/Create
        public ActionResult Create()
        {
            return View();
        }

        /// POST: Registrations/Create
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegisterKey")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                registrationService.Add(registration);
                return RedirectToAction("Index");
            }

            return View(registration);
        }

        /// GET: Registrations/Edit/Id
        public ActionResult Edit(int Id)
        {
            Registration registration = registrationService.ToEdit(Id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        /// POST: Registrations/Edit/Id
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegisterKey")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                registrationService.Edit(registration);
                return RedirectToAction("Index");
            }
            return View(registration);
        }

        /// GET: Registrations/Delete/Id
        public ActionResult Delete(int Id)
        {
            Registration registration = registrationService.ToDelete(Id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        /// POST: Registrations/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            registrationService.DeleteConfirmed(Id);
            return RedirectToAction("Index");
        }
    }
}
