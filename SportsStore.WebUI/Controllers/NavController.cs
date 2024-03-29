﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        IproductsRepository repository;
        public NavController(IproductsRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {

            ViewBag.Selectedcategory = category;
            IEnumerable<string> categories = repository.Products
                                                      .Select(x => x.Category)
                                                      .Distinct()
                                                      .OrderBy(x=>x);
            return PartialView(categories);
        }   
    }
}