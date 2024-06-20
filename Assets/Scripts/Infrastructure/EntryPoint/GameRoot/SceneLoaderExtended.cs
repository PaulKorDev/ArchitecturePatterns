using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EntryPoint
{
    public static class SceneLoaderExtended
    {
        public static IEnumerator LoadBootstrapScene()
        {
            yield return SceneLoader.LoadAndInitScene(Scenes.BOOTSTRAP);
        }
        public static IEnumerator LoadMenuScene()
        {
            yield return SceneLoader.LoadAndInitScene(Scenes.MENU);
        }
        public static IEnumerator LoadGameplayScene()
        {
            yield return SceneLoader.LoadAndInitScene(Scenes.GAMEPLAY);
        }
        public static IEnumerator SwitchScenesWithLoadingScreen(string sceneName, GameObject uiLoadingScreen)
        {
            uiLoadingScreen.SetActive(true);
            yield return SceneLoader.LoadAndInitScene(sceneName);
            uiLoadingScreen.SetActive(false);
        }
    }
}
