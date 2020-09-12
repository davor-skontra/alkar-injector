using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlkarInjector
{
    public static class Alkar
    {
        private static Dictionary<Type, KnownType> _knownTypes = new Dictionary<Type, KnownType>();
        
        public static void AlkarInject<TMonoBehaviour>(this TMonoBehaviour self) where TMonoBehaviour : MonoBehaviour
        {
            var type = typeof(TMonoBehaviour);

            if (!_knownTypes.ContainsKey(type))
            {
                _knownTypes[type] = new KnownType(type);
            }
            
            _knownTypes[type].Resolve(self);
        }

        public static void AlkarInject<TType>(this object self)
        {
            var type = typeof(TType);

            if (!_knownTypes.ContainsKey(type))
            {
                _knownTypes[type] = new KnownType(type);
            }
            
            _knownTypes[type].Resolve(self);
        }

        public static class Services
        {
            private static Dictionary<Type, object> _services = new Dictionary<Type, object>(); 
            public static void Register<TService>(TService service)
            {
                var type = typeof(TService);
                
                if (_services.ContainsKey(type))
                {
                    throw ServiceLocatorException.ShouldNotExist(type);
                }
                _services[type] = service;
            }

            public static void Register<TRegisterAs, TService>(TService service) where TService: TRegisterAs
            {
                Register((TService) service);
            }

            public static object ResolveAnonymous(Type type)
            {
                if (_services.ContainsKey(type))
                {
                    return _services[type];
                }
                throw ServiceLocatorException.ShouldExist(type);
            }

            public static TType Resolve<TType>() => (TType) ResolveAnonymous(typeof(TType));

            public class ServiceLocatorException : Exception
            {
                private ServiceLocatorException(string message) : base(message)
                {
                    
                }
                
                public static ServiceLocatorException ShouldNotExist(Type type) => 
                    new ServiceLocatorException($"Service Locator already contains type {type})");
                
                public static ServiceLocatorException ShouldExist(Type type) => 
                    new ServiceLocatorException($"Service Locator does not contains type {type})");
            }
        }
    }
}