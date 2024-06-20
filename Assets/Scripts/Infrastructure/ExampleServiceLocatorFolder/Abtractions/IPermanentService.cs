using Assets.Scripts.Infrastructure.ServiceLocator;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions
{
    public interface IPermanentService : IService
    {
        public void SayHelloFromPermanentService();
    }
}
