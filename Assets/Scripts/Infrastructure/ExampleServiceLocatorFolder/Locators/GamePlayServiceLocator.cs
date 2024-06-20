using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions;
using Assets.Scripts.Infrastructure.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Locators
{
    public class GamePlayServiceLocator
    {
        [SerializeField] private GamePlayService _gamePlayService;

        private IGameplayConfigService _gamePlayConfigService = new GameplayConfigService();

        public void Init()
        {
            ServiceLocator.ServiceLocator.Register(_gamePlayConfigService);
            ServiceLocator.ServiceLocator.Register(_gamePlayService);
        }
        private void OnDestroy()
        {
            ServiceLocator.ServiceLocator.Unregister(_gamePlayConfigService);
            ServiceLocator.ServiceLocator.Unregister(_gamePlayService);
        }
    }
}
