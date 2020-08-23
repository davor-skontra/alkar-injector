using UnityEngine;

namespace Examples.Scripts
{
    public class NormalMonoBehaviour : MonoBehaviour
    {
        private Rigidbody2D _r;

        private void Awake()
        {
            _r = GetComponent<Rigidbody2D>();
        }
    }
}