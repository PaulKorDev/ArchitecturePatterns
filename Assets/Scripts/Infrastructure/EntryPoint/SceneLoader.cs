using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Infrastructure.EntryPoint
{
    public class SceneLoader
    {
        public static IEnumerator LoadAndInitScene(string sceneName, params object[] args)
        {
            yield return LoadScene(sceneName);
            InitScene(args);


        }
        private static IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(Scenes.TRANSIT);
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return new WaitForEndOfFrame();
        }
        private static void InitScene(params object[] args)
        {
            RootLoader rootLoader = GameObject.FindFirstObjectByType<RootLoader>();
            if (rootLoader != null) rootLoader.Run();
        }



    }
}
