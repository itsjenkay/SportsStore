using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

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

        public ViewResult List(string category ,int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = repository.Products
                                     .Where(p=>category==null || p.Category==category)
                                     .OrderBy(p => p.ProductID)
                                     .Skip((page - 1) * PageSize)
                                     .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()

                }
                ,
                currentCategory=category

            };
            return View(model);
        }

    }
}