using System;
using System.Collections;
using System.Collections.Generic;

namespace SIS.MvcFramework.Services
{
    public class ServiceCollection : IServiceCollection
    {
        private IDictionary<Type, Type> dependencyContainer;

        public ServiceCollection()
        {
            this.dependencyContainer = new Dictionary<Type, Type>();
        }

        public void AddService<TSource, TDestination>()
        { 

        }
    }
}

