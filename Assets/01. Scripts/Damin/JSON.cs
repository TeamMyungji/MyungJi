using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JSON : MonoBehaviour
{
    public Data playerData;

    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson()
    {
        string JsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath, "PlayerData.json");

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(JsonData);
        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(path, code);
        Debug.Log(code);
    }

    [ContextMenu("Load Json Data")]
    public void LoadPlayerDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        string jsonData = File.ReadAllText(path);

        byte[] bytes = System.Convert.FromBase64String(jsonData);
        string jdata = System.Text.Encoding.UTF8.GetString(bytes);
        playerData = JsonUtility.FromJson<Data>(jdata);
    }

    [ContextMenu("Print")]
    public void DataPrint()
    {
        Debug.Log($"처음 시작하는 유저인가? : {playerData.FirstPlayUser}");
        Debug.Log($"돈의 양 : {playerData.Money}");
        Debug.Log($"빚의 양 : {playerData.RemainingMoney}");
        Debug.Log($"로또 참여 횟수 : {playerData.CurLottoCount}");
        Debug.Log($"로또 제한 : {playerData.LimitLottoCount}");
        Debug.Log($"오늘 날짜 : {playerData.todayTime}");
        Debug.Log($"어제 날짜 : {playerData.yesterdayTime}");
    }
}

[System.Serializable]
public class Data
{
    public bool FirstPlayUser = false;
    public int Money;
    public int RemainingMoney;
    public int CurLottoCount;
    public int LimitLottoCount = 5;
    public DateTime todayTime;
    public DateTime yesterdayTime;
}
