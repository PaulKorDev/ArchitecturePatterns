using UnityEngine;
using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions;

namespace Infrastructure.ServiceLocator.ExampleFolder
{
    internal class MyMenuService : MonoBehaviour, IMenuService
    {
        public void SayHelloFromMenu()
        {
            Debug.Log("I'm menu service");
        }

    }
}
