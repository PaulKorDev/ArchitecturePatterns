using Assets.Scripts.Infrastructure.EntryPoint.GameRoot;
using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Locators;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EntryPoint.BootstrapRoot
{
    public class ProjectBootStrapEntryPoint : MonoBehaviour
    {
        [SerializeField] private ProjectServiceLocator _generalServiceLocator;

        private bool _initializated = false;
        public void Run()
        {
            if (_initializated) 
                return;

            //Here you can init all project services, controllers and managers
            //  Init ui
            //  Init global dependencies (ServiceLocator/DI)
            //  Init InputController
            //  Init Cloud
            //  Init Localization
            //  Init Storage
            //  and other controllers and services

            _generalServiceLocator.Init();

            Debug.Log("Bootstrap inited");
            DontDestroyOnLoad(gameObject);
            _initializated = true;
        }
    }
}
