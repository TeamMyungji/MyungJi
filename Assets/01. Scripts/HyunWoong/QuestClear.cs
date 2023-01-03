using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;
public class QuestClear : MonoBehaviour,IQuest
{
    public List<MoneyAndStarPointSO> moneys = new();

    [Header("GameObject")]
    [SerializeField] GameObject _fireWork = null;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI moneyTxt;

    [Header("amount")]
    public int curMoney;
    public float curStarPoint;
    [SerializeField] private MoneySO money; //float 형식으로 변경 요구

    [Header("JSON")]
    private JSON _json;
    private Data _data;

    public Phone phone;

    //(대충 GetComponent 하는곳)
    private void Awake()
    {
        moneyTxt = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        phone = GameObject.Find("Phone").GetComponent<Phone>();
        _json = GameObject.Find("GameManager").GetComponent<JSON>();
        _json.LoadPlayerDataToJson();
        _data = _json.playerData;
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        print(other.tag);
        if (other.CompareTag("Player"))
        {
            print("efae");
            //(클리어부분(돈 받는부분))
            Cleared();

            //GameObject FW = Instantiate(_fireWork, transform.position, Quaternion.identity);//폭죽 이펙트 생성해줌.
            //Destroy(gameObject, 1f);
            //Destroy(FW, 3f);
        }
    }

    public void Cleared()
    {
        DeliveryMain.instance.isDelivering = false;
        DeliveryManager.instance.DeliveryButtonReset();
        GameObject.Find("DeliveryingPage").GetComponent<RectTransform>().anchoredPosition = new Vector3(350, 30, 0);

        int i = Random.Range(0, 3);
        PointCalculator(i);
    }

    ///<summary>
    ///id값과 일치하는 인덱스의 돈의 값과, 별점의 값을 더해주고, 텍스트를 띄우는 함수를 살행
    ///</summary>
    public void PointCalculator(int id)//summary에서 변수 설명하는게 뭔지 까먹음;;
    {
        print(1);
        money.cullMoney += moneys[id].payment;
        curStarPoint += moneys[id].starPoint;
        MoneyTxtChanges(moneys[id].payment);
    }

    ///<summary>
    ///들어오는 돈을 받고, 그 돈의 텍스트를 띄워주는 함수
    ///</summary>
    public void MoneyTxtChanges(int money)
    {
        print(curStarPoint);
        moneyTxt.text = $"+{money} Myungji";//이게 원래 별점이 늘어날 수록 받는 돈이 많아지는건데 이거는 차차 상의를 해야함

        Sequence seq = DOTween.Sequence();

        seq.Append(moneyTxt.rectTransform.DOAnchorPosY(0, 1f));
        seq.Append(moneyTxt.rectTransform.DOAnchorPosY(600, 1f));

        seq.AppendCallback(() =>
        {
            phone._moneyText.text = $"{this.money.cullMoney}Myungji";
            moneyTxt.rectTransform.anchoredPosition = new Vector2(0f, -600f);
            seq.Kill();
            Destroy(this.gameObject);
        });
    }
}
