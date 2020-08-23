using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlkarInjector
{
    public static class Alkar
    {
        private static Dictionary<Type, KnownType> _knownTypes = new Dictionary<Type, KnownType>();
        
        public static void Inject<TMonoBehaviour>(TMonoBehaviour monoBehaviour) where TMonoBehaviour : MonoBehaviour
        {
            var type = typeof(TMonoBehaviour);

            if (!_knownTypes.ContainsKey(type))
            {
                _knownTypes[type] = new KnownType(type);
            }
            
            _knownTypes[type].Resolve(monoBehaviour);
        }
    }
}