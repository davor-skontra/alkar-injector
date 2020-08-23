using System;
using AlkarInjector;
using AlkarInjector.Attributes;
using UnityEngine;

namespace Examples.Scripts
{
    public class InjectedMonoBehaviour : MonoBehaviour
    {
        [FromOwnComponent]
        private Rigidbody2D _r;

        private void Start()
        {
            Alkar.Inject(this);
            
            Debug.Log($"is null {(_r == null).ToString()}");
        }
    }
}