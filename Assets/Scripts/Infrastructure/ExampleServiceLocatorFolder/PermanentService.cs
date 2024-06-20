using UnityEngine;
using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder
{
    public class PermanentService : IPermanentService
    {
        public void SayHelloFromPermanentService()
        {
            MonoBehaviour.print("I am important monobehaviour permanent service");
        }
    }
}
