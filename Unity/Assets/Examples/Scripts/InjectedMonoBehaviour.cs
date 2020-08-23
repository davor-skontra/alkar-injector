using System;
using System.Linq;
using AlkarInjector;
using AlkarInjector.Attributes;
using UnityEngine;

namespace Examples.Scripts
{
    public class InjectedMonoBehaviour : MonoBehaviour
    {
        [InjectComponent]
        private Rigidbody2D _r;

        [InjectChildComponents]
        private Collider2D[] _c;

        private void Awake()
        {
            Alkar.Inject(this);
            
            Debug.Log(string.Join(",", _c.Select(x => x.name)));
        }
    }
}