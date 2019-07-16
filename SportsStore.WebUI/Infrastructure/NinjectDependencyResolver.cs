using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //put bindings here

            Mock<IproductsRepository> mock = new Mock<IproductsRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
                new Product{Name="Footbaall",Price=25},
                new Product{Name="Surf board", Price=179},
                new Product{Name="Running shoes", Price =95}

            });
           
            kernel.Bind<IproductsRepository>().ToConstant(mock.Object);
        }

    }
}