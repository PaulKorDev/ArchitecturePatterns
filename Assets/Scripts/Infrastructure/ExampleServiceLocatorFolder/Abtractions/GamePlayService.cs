using Assets.Scripts.Infrastructure.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions
{
    public abstract class GamePlayService : MonoBehaviour, IService
    {
        public abstract Text TextBox { get; }
        public abstract void Init();
    }
}
