using AlkarInjector;
using AlkarInjector.Attributes;

namespace Examples.Scripts
{
    public class SimpleObject
    {
        [InjectService] private IInjectedService _injectedService;
        
        public SimpleObject()
        {
            Alkar.Inject(this);
            
            _injectedService.SayHello();
        }
    }
}