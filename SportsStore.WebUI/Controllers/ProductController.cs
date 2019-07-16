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
        public int PageSize = 4;

        public ProductController(IproductsRepository repositoryParam)
        {
            this.repository = repositoryParam;
        }
        
        public ViewResult List(int page=1)
        {

            return View(repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));
        }

    }
}