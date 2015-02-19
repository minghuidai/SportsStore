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
        public ViewResult List()
        {
            return View(repository.Products);
        }

 
	}
}