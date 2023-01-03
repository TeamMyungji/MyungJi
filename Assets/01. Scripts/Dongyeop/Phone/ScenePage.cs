using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePage : MonoBehaviour
{
    [SerializeField] private string _sceneSTR;
    [SerializeField] private string _lottoScene;
    [SerializeField] private string _reload;

    public void SceneChange()
    {
        UIFadeController.instance.DissolveOn(); 
        SceneLoader.Instance.LoadScene(_sceneSTR);
    }

    public void LottoScene()
    {
        UIFadeController.instance.DissolveOn();
        SceneLoader.Instance.LoadScene(_lottoScene);
    }

    public void ReloadScene()
    {
        UIFadeController.instance.DissolveOn();
        SceneLoader.Instance.LoadScene(_reload);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
