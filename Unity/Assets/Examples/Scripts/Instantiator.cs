using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Examples.Scripts
{
    public class Instantiator : MonoBehaviour
    {
        [SerializeField] private GameObject item;
        [SerializeField] private int count;

        private void Start()
        {
            var s = new Stopwatch();
            s.Start();
            for (var i = 0; i < count; i++)
            {
                Instantiate(item);
            }
            s.Stop();
            Debug.Log($"{item.name}, count: {count}: Elapsed time: {s.Elapsed}");
        }
    }
}