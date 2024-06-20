using Assets.Scripts.Infrastructure.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EntryPoint.GameRoot
{
    public class UIRootView : MonoBehaviour, IService
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private GameObject _menuScreen;
        [SerializeField] private GameObject _gameplayScreen;
        
        public GameObject MenuScreen => _menuScreen;
        public GameObject GameplayScreen => _gameplayScreen;

        private void Awake()
        {
             HideLoadingScreen();   
        }

        public void HideLoadingScreen() => _loadingScreen.SetActive(false);
        public void ShowLoadingScreen() => _loadingScreen.SetActive(true);
    }
}
