using Assets.Scripts.Infrastructure.EntryPoint;
using Assets.Scripts.Infrastructure.EntryPoint.GameRoot;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.EntryPoint.GameRoot
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private UIRootView _uiRoot;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStart()
        {
            Application.targetFrameRate = 60;
            //For mobile game
            //Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint() {
            //Create UI
            var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = GameObject.Instantiate(prefabUIRoot);
            GameObject.DontDestroyOnLoad(_uiRoot.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == Scenes.GAMEPLAY || 
                currentSceneName == Scenes.MENU || 
                currentSceneName == Scenes.BOOTSTRAP) {
                _uiRoot.StartCoroutine(LoadAndStartFirstScreen());
                return;
            }
            else if (currentSceneName != Scenes.TRANSIT)
            {
                return;
            }
#endif
            _uiRoot.StartCoroutine(LoadAndStartFirstScreen());
        }

        private IEnumerator LoadAndStartFirstScreen()
        {
            _uiRoot.ShowLoadingScreen();

            yield return SceneLoaderExtended.LoadBootstrapScene();
            yield return SceneLoaderExtended.LoadMenuScene();

            _uiRoot.HideLoadingScreen();
        }

    }
}
