using AlkarInjector;
using AlkarInjector.Attributes;

namespace Examples.Scripts
{
    public class SimpleObject
    {
        [InjectService] private Instantiator _instantiator;
        
        public SimpleObject()
        {
            this.AlkarInject<SimpleObject>();
        }
    }
}