using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrect;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="kernelParam"></param>
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }


        /// <summary>
        /// Get an instance of server type
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }


        /// <summary>
        /// Get all instances for a service type
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }



        /// <summary>
        /// Add all bindings.
        /// </summary>
        private void AddBindings()
        {
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product { Name = "Football", Price = 25m },
            //    new Product { Name = "Surf board", Price = 179m },
            //    new Product { Name = "Running shoes", Price = 95m }
            //});

            // put bindings here
            kernel.Bind<IProductsRepository>().To<EFProductsRepository>();

            // Bind AuthProvider
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

        }

    }
}