using Assets.Scripts.Infrastructure.ServiceLocator;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions
{
    public interface IGameplayConfigService : IService
    {
        public string GamePlayText { get; }
    }
}
