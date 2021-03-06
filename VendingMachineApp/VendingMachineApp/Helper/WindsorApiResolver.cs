﻿using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace VendingMachineApp.Helper
{
    public sealed class WindsorApiResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorApiResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Dispose()
        {

        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }
    }

    public sealed class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private bool _disposed;
        private IDisposable _scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            _container = container;
            _scope = container.BeginScope();
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            if (_scope != null)
            {
                _scope.Dispose();
                _scope = null;
            }

            _disposed = true;

            GC.SuppressFinalize(this);
        }

        public object GetService(Type serviceType)
        {
            EnsureNotDisposed();

            return _container.Kernel.HasComponent(serviceType) ? _container.Kernel.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            EnsureNotDisposed();

            return _container.ResolveAll(serviceType).Cast<object>();
        }

        private void EnsureNotDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("WindsorDependencyScope");
        }
    }
}