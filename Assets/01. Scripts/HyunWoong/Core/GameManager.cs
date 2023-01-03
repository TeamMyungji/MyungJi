using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoSingleton<GameManager>//이거는 Monosingleton테스트겸 fade테스트
{
    [Header("other scripts")]
    public JSON JSON;

    [Header("UI")]
    public RectTransform tuto;

    public MoneySO money;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Data data = JSON.playerData;
        //money.cullMoney = data.Money;
        data.todayTime = System.DateTime.Today;

        if(data.todayTime>= data.yesterdayTime)
        {
            data.CurLottoCount = 0;
        }

        if (data.FirstPlayUser)
        {
            UIOn();
        }

        data.FirstPlayUser = false;
        JSON.SavePlayerDataToJson();
    }

    private void Start() 
    {
        GameObject.Find("ButtonSelect").GetComponent<TitleUIManager>().enabled = true;
    }

    public void UIOn()
    {
        //설명 UI나옴
    }

    [ContextMenu("FirstPlay is Off")]
    public void FirstPlayOff()
    {
        Data data = JSON.playerData;
        data.FirstPlayUser = true;
        JSON.SavePlayerDataToJson();
    }
}
