using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [Header ("BankApp")]
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private GameObject _lackOfMoneyTxt;
    [SerializeField] private TextMeshProUGUI _repaymentAmount;
    [SerializeField] private int _lackOfMoneyTxtTime = 1;

    [Header("Money")]
    [SerializeField] private MoneySO _money;

    [Header("JSON")]
    public JSON json;
    private Data _data;

    private void Awake() 
    {
        json.LoadPlayerDataToJson();
        _data = json.playerData;
    }

    private void Update()
    {
        _repaymentAmount.text = $"{_money.cullDebt} MyungZi";
    }

    public void RepaymentButtonClick()
    {
        int pay = int.Parse(_inputField.text);
        
        if (int.Parse(_inputField.text) > _money.cullMoney || pay < 0)
        {
            StopAllCoroutines();
            StartCoroutine(LackOfMoneyTxt());
            return;
        }

        _money.cullDebt -= pay;
        _money.cullMoney -= pay;
        
        if (_money.cullDebt <= 0)
        {
            UIFadeController.instance.DissolveOn();
            SceneLoader.Instance.LoadScene("Ending"); 
        }

    }

    private IEnumerator LackOfMoneyTxt()
    {
        _lackOfMoneyTxt.SetActive(true);
        yield return new WaitForSeconds(_lackOfMoneyTxtTime);
        _lackOfMoneyTxt.SetActive(false);
    }
}
