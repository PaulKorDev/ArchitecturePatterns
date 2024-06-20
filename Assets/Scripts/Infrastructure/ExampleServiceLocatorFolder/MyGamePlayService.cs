using Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder.Abstractions;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.ExampleServiceLocatorFolder
{
    public class MyGamePlayService : GamePlayService
    {
        private Text _textBox;
        public override Text TextBox => _textBox;

        public override void Init()
        {
            _textBox = GetComponent<Text>();
        }

    }
}
