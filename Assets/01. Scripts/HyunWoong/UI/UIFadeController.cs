using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeController : MonoSingleton<UIFadeController>
{
    public static UIFadeController instance;

    [SerializeField]
    private bool _isDissolveOn = false;

    [SerializeField]
    private Image fadeImage;

    float fade;

    Material material;

    private void Awake()
    {
        material = fadeImage.transform.GetComponent<Image>().material;
        instance = this;
        Application.targetFrameRate = 30;
    }

    private void Start()
    {
        fade = 1000;
        material.SetFloat("_Cutoff_Height", fade);
    }

    private void Update()
    {
        if (_isDissolveOn)
        {
            fade += 30;

            if (fade >= 1000)
            {
                fade = 1000;
            }

            material.SetFloat("_Cutoff_Height", fade);
        }
        else
        {
            fade -= 30;

            if (fade <= -1000)
            {
                fade = -1000;
            }

            material.SetFloat("_Cutoff_Height", fade);
        }
    }

    public void DissolveOn()
    {
        _isDissolveOn = true;
    }

}
