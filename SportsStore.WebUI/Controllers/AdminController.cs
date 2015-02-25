using SportsStore.Domain.Abstract;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {

        private IProductsRepository repository;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        public AdminController(IProductsRepository productRepository)
        {
            repository = productRepository;
        }


        // GET: Admin
        [HttpGet]
        public ViewResult Index()
        {
            return View(repository.Products);
        }


        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
    }
}