using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder
{
    internal class ClientTextReplacer : MonoBehaviour
    {
        public void Init()
        {
            string gameplayText = ServiceLocator.ServiceLocator.Get<IGameplayConfigService>().GamePlayText;
            Text textBox = ServiceLocator.ServiceLocator.Get<GamePlayService>().TextBox;
            textBox.text = gameplayText;
        }

    }
}
