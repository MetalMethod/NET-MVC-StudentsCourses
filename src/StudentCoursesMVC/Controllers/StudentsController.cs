﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCoursesMVC.Models;
using StudentCoursesMVC.Models.EntityModels;
using StudentCoursesMVC.Services;

namespace StudentCoursesMVC.Controllers
{
    public class StudentsController : Controller
    {
        //Services from Unity Dependency Injection
        private readonly IStudentService studentService;

        // Constructor with Unity Dependency Injection
        public StudentsController(IStudentService StudentService)
        {
            studentService = StudentService;
        }

        // GET: Students
        public ActionResult Index()
        {
            return View(studentService.GetAll());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Students student)
        {
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Students student)
        {
            return View(student);
        }

        // GET: Students/Delete
        public ActionResult Delete()
        {
            return View();
        }

    }
}