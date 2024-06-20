using Assets.Scripts.Infrastructure.EntryPoint.GameRoot;
using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Locators
{
    class ProjectServiceLocator : MonoBehaviour
    {
        IPermanentService permanentService = new PermanentService();
        public void Init()
        {
            ServiceLocator.ServiceLocator.Register(permanentService);

            UIRootView rootView = GameObject.FindAnyObjectByType<UIRootView>();
            ServiceLocator.ServiceLocator.Register(rootView);

            //Test
            Debug.Log("Project servicelocator inited");
            ServiceLocator.ServiceLocator.Get<IPermanentService>().SayHelloFromPermanentService();
        }
    }
}
