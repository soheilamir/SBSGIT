using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using System.Diagnostics.Contracts;
using System.Collections;

namespace SBSWebProject.Web.Common
{
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _container;
        public NinjectDependencyResolver(IKernel container)
        {
            _container = container;
        }
        public IKernel Container
        {
            get { return _container; }
        }
        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    //public class NinjectDependencyScope : IDependencyScope
    //{
    //    private IResolutionRoot resolver;

    //    internal NinjectDependencyScope(IResolutionRoot resolver)
    //    {
    //        Contract.Assert(resolver != null);
    //        this.resolver = resolver;
    //    }

    //    public void Dispose()
    //    {
    //        IDisposable disposable = resolver as IDisposable;
    //        if (disposable != null)
    //            disposable.Dispose();
    //        resolver = null;
    //    }

    //    public object GetService(Type serviceType)
    //    {
    //        if (resolver == null)
    //            throw new ObjectDisposedException("this", "This scope has already been disposed");

    //        return resolver.TryGet(serviceType);
    //    }

    //    public IEnumerable<object> GetServices(Type serviceType)
    //    {
    //        if (resolver == null)
    //            throw new ObjectDisposedException("this", "This scope has already been disposed");

    //        return resolver.GetAll(serviceType);
    //    }
    //}

    //public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    //{
    //    private IKernel kernel;
    //    public NinjectDependencyResolver(IKernel kernel)
    //        : base(kernel)
    //    {
    //        this.kernel = kernel;
    //    }

    //    public IDependencyScope BeginScope()
    //    {
    //        return new NinjectDependencyScope(kernel.BeginBlock());
    //    }
    //}
}
