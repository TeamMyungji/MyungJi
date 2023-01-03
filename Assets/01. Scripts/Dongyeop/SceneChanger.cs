using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string _nextScene;

    public void SceneChange()
    {
        Time.timeScale = 1;
        SceneLoader.Instance.LoadScene(_nextScene);
        UIFadeController.instance.DissolveOn();
    }

    public void GameExit()
    {
        Time.timeScale = 1;
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
