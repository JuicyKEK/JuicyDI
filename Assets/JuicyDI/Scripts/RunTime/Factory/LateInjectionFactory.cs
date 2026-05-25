using System;
using System.Collections.Generic;
using System.Linq;

namespace JuicyDI.Scripts.RunTime.Factory
{
    public class LateInjectionFactory : ILateInjectionFactory
    {
        private Dictionary<Type, Func<object[], object>> m_Factories = new();
        
        public object ConstructorLateInjection(Type type, object[] runtimeArgs)
        {
            if (!m_Factories.TryGetValue(type, out var factory))
            {
                factory = BuildFactory(type);
                m_Factories[type] = factory;
            }

            return factory(runtimeArgs);
        }
        
        private Func<object[], object> BuildFactory(Type type)
        {
            var constructor = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault();

            if (constructor == null)
            {
                throw new Exception($"No public constructor found for {type}");
            }

            return (object[] runtimeArgs) =>
            {
                var instance = constructor.Invoke(runtimeArgs);

                return instance;
            };
        }
    }
}