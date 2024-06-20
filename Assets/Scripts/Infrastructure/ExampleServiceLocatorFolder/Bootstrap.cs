using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions;
using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Locators;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] GamePlayServiceLocator _gamePlayServiceLocator;
        [SerializeField] GamePlayService _gamePlayService;
        [SerializeField] ClientTextReplacer _client;

        private void Awake()
        {
            _gamePlayService.Init();
            _gamePlayServiceLocator.Init();
            _client.Init();
        }

    }
}
