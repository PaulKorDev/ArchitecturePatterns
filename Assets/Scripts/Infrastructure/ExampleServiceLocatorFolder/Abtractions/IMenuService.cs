using Assets.Scripts.Infrastructure.ServiceLocator;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions
{
    //For each concrete service, you need to create an interface with IService as the parent.
    public interface IMenuService : IService
    {
        public void SayHelloFromMenu();
    }
}
