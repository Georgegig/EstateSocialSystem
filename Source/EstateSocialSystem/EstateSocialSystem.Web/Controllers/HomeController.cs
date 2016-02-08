﻿using EstateSocialSystem.Data.Common.Repository;
using EstateSocialSystem.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateSocialSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Estate> estates;

        public HomeController(IDeletableEntityRepository<Estate> estates)
        {
            this.estates = estates;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var model = this.estates.All().Where(m => m.AuthorId == userId);

            return this.View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}