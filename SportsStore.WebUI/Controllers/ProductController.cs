using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IproductsRepository repository;

        public ProductController(IproductsRepository repositoryParam)
        {
            this.repository = repositoryParam;
        }
        
        public ViewResult List()
        {
            return View(repository.Products);
        }

    }
}