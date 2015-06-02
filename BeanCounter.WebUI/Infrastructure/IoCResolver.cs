using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Ninject;

using BeanCounter.Domain.Abstract;
using BeanCounter.Domain.Concrete;
using BeanCounter.Domain.Entities;

namespace BeanCounter.WebUI.Infrastructure
{
    public class IoCResolver : IDependencyResolver
    {
        private static IKernel kernel;

        public IoCResolver(IKernel kernelParam)
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

        public static T Resolve<T>()
        {
            return kernel.Get<T>();
        }
        public static T TryResolve<T>()
        {
            return kernel.CanResolve<T>() ? kernel.Get<T>() : default(T);
        }

        public static void Release(object o)
        {
            kernel.Release(o);
        }

        private void AddBindings()
        {
            kernel.Bind<IAccoutRepository>().To<EFAccountRepository>();
            kernel.Bind<IAddExpenses>().To<EFCategoryRepository>();
        }
    }
}