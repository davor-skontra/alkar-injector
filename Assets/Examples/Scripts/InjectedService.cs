using UnityEngine;

namespace Examples.Scripts
{
    public interface IInjectedService
    {
        void SayHello();
    }

    public class InjectedService : IInjectedService
    {
        public void SayHello()
        {
            Debug.Log("hello");
        }
    }
}