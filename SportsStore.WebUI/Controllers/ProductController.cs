using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductController(IProductsRepository productRepository)
        {
            repository = productRepository;
        }



        /// <summary>
        /// Action to list all products
        /// </summary>
        /// <returns></returns>
        public ViewResult List(int page = 1)
        {
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
        }

 
	}
}