using Examples.Scripts;
using UnityEngine;
using Services = AlkarInjector.Alkar.Services;

public class CompositionRoot : MonoBehaviour
{
    private void Awake()
    {
        Services.Register(new InjectedService());
    }
}
