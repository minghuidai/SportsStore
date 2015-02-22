using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.WebUI.HtmlHelpers;
using System.Web.Mvc;


namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
                new Product { ProductID = 4, Name = "P4" },
                new Product { ProductID = 5, Name = "P5" },
            });

            var controller = new ProductController(mock.Object);
            controller.PageSize = 4;

            ProductListViewModel result = (ProductListViewModel)controller.List(2).Model;

            Product[] prodArr = result.Products.ToArray();

            // Assert
            Assert.AreEqual(prodArr.Length, 1);
            Assert.AreEqual(result.PagingInfo.CurrentPage, 2);



        }


        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Define an HTML helper - we need to do this in order to apply the extension method.
            HtmlHelper myHelper = null;

            // Create Pageinfo data
            var pagingInfo = new PagingInfo()
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10,
            };

            // setup the delegate function for page url
            Func<int, string> pageUrlDelegage = i => "Page" + i;

            // act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegage);


            string expectedValue = "<a class=\"btn btn-default\" href=\"Page1\">1</a><a class=\"btn btn-default btn-primary selected\" href=\"Page2\">2</a><a class=\"btn btn-default\" href=\"Page3\">3</a>";


            // Assert
            Assert.AreEqual(expectedValue, result.ToString());


        }


    }
}
