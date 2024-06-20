using Assets.Scripts.Infrastructure.EntryPoint.GameRoot;
using Assets.Scripts.Infrastructure.ServiceLocator;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    public void Run()
    {
        ServiceLocator.Get<UIRootView>().MenuScreen.SetActive(true);
        Debug.Log("Menu scene initializated");
    }
    private void OnDestroy()
    {
        ServiceLocator.Get<UIRootView>().MenuScreen.SetActive(false);
    }
}
