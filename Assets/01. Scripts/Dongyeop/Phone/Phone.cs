using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

enum ThisPage { Main, DeliveryApplication, Bank, SoundManager, Scene }

public class Phone : MonoBehaviour
{
    [SerializeField] private float _moveTime = 1f;

    [Header ("In Phone")]
    private RectTransform _phone;
    [SerializeField] private GameObject _mainPage;
    [SerializeField] private RectTransform _deliceryPage;
    [SerializeField] private GameObject _bankPage;
    [SerializeField] private GameObject _scenePage;
    [SerializeField] private GameObject _soundPage;

    [Header("Money")]
    [SerializeField] private MoneySO _money;
    public TextMeshProUGUI _moneyText;

    [Header("JSON")]
    public JSON json;
    private Data _data;

    private ThisPage _thisPage = ThisPage.Main;

    private bool _isMove = false;
    private bool _isPhoneOn = true;

    private void Awake()
    {
        json.LoadPlayerDataToJson();
        _data = json.playerData;

        _phone = GetComponent<RectTransform>();

        _moneyText.text = $"{_money.cullMoney}Myungji";
            return;

        if (!_isPhoneOn)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _isPhoneOn = true;
                PhoneMove(675);
            }
        }
        else if (_isPhoneOn)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _isPhoneOn = false;
                PhoneMove(-675);
            }
        }
    }

    private void Update() 
    {
        _moneyText.text = $"{_money.cullMoney}Myungji";
    }

    private void PhoneMove(int movePos)
    {
        _isMove = true;
        
        Sequence seq = DOTween.Sequence();
        seq.Append(_phone.DOAnchorPosY(_phone.anchoredPosition.y + movePos, _moveTime));
        seq.OnComplete(() =>
        {
            _isMove = false;
        });
    }

    #region Button Click

    public void BackButtonClick()
    {
        AppSelect(_thisPage);
        _mainPage.SetActive(true);
        _thisPage = ThisPage.Main;
    }

    public void DeliveryAppClick()
    {
        AppSelect(_thisPage);
        _deliceryPage.anchoredPosition = new Vector3(0,0,0);
        _thisPage = ThisPage.DeliveryApplication;
    }

    public void BankButtonClick()
    {
        AppSelect(_thisPage);
        _bankPage.SetActive(true);
        _thisPage = ThisPage.Bank;
    }

    public void SceneButtonClick()
    {
        AppSelect(_thisPage);
        _scenePage.SetActive(true);
        _thisPage = ThisPage.Scene;
    }

    public void SoundButtonClick()
    {
        AppSelect(_thisPage);
        _soundPage.SetActive(true);
        _thisPage = ThisPage.SoundManager;
    }

    private void AppSelect(ThisPage thisPage)
    {
        switch (_thisPage)
        {
            case ThisPage.Main:
                _mainPage.SetActive(false);
                break;
            case ThisPage.DeliveryApplication:
                _deliceryPage.anchoredPosition = new Vector3(350,0,0);
                break;
            case ThisPage.Bank:
                _bankPage.SetActive(false);
                break;
            case ThisPage.Scene:
                _scenePage.SetActive(false);
                break;
            case ThisPage.SoundManager:
                _soundPage.SetActive(false);
                break;
        }
    }

    #endregion
}
