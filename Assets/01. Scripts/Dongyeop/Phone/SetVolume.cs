using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private Slider _matserVolumeSlider;
    private Slider _bgmVolumeSlider;
    private Slider _effectVolumeSlider;

    private void Awake()
    {
        #region ����� Sldier�� ����
        _matserVolumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
        _bgmVolumeSlider = GameObject.Find("BGMVolumeSlider").GetComponent<Slider>();
        _effectVolumeSlider = GameObject.Find("EffectVolumeSlider").GetComponent<Slider>();
        #endregion
    }

    private void Start()
    {
        #region ���� PlayerPrefs�� ����� ���� ���ٸ�
        if (!PlayerPrefs.HasKey("MasterVolume"))
            PlayerPrefs.SetFloat("MasterVolume", 1f);
        if (!PlayerPrefs.HasKey("BGMVolume"))
            PlayerPrefs.SetFloat("BGMVolume", 1f);
        if (!PlayerPrefs.HasKey("EffectVolume"))
            PlayerPrefs.SetFloat("EffectVolume", 1f);
        #endregion

        #region Slider�� ��ġ�� ����� ������ ����
        _matserVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        _bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        _effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume");
        #endregion

        #region AudioMixer�� ���� ���޵� ������ ����
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume")) * 20);
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(PlayerPrefs.GetFloat("BGMVolume")) * 20);
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectVolume")) * 20);
        #endregion
    }

    #region Slider
    public void MasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    public void BGMVolume(float sliderValue)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("BGMVolume", sliderValue);
    }

    public void EffectVolume(float sliderValue)
    {
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("EffectVolume", sliderValue);
    }
    #endregion

}
