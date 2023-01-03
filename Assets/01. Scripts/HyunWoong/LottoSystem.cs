using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
//변경사항 생각하기

public class LottoSystem : MonoBehaviour
{
    int[] randNum = new int[6];

    int[] inputNum = new int[6];


    [Header("TMP")]
    public TMP_InputField[] inputFields;
    public TextMeshProUGUI txt;
    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI curCount;
    
    [Header("JSON")]
    public JSON JSON;
    Data data;

    [Header("Vectors")]
    private Vector3 pos = new Vector3(0,-3.6f,0);
    public RectTransform images;

    [Header("GO")]
    public GameObject button;
    public GameObject fireWork;

    [Header("Audio")]
    public List<AudioSource> audioSources;
    public AudioClip clip;

    public MoneySO money;

    private void Awake()
    {
        JSON.LoadPlayerDataToJson();
        data = JSON.playerData;

        curCount.text = $"{data.LimitLottoCount - data.CurLottoCount}회 남음";
        moneyTxt.text = $"{money.cullMoney}Myungji";
    }

    /// <summary>
    /// 랜덤 수 뽑는 함수
    /// </summary>
    public void RandNum(int input)
    {
        for (int i = 0; i < input; i++)
        {
            randNum[i] = Random.Range(1, 35);
        }
    }

    /// <summary>
    /// 숫자가 맞는지 맞지 않는지 확인하는 함수
    /// </summary>
    public void LottoEvent()
    {

        int cnt = 0;

        RandNum(6);
        if (data.CurLottoCount < data.LimitLottoCount)
        {
            if(money.cullMoney == 0 || money.cullMoney - 2500 <= 0)
            {
                txt.DOText("돈이 부족합니다.", 0.5f);
            }
            else
            {

                data.CurLottoCount++;
                money.cullMoney -= 2500;
                for (int i = 0; i < randNum.Length; i++)
                {
                    print($"{randNum[i]}와 {inputNum[i]}를 비교했습니다.");
                    if (inputNum[i] == randNum[i])
                    {
                        //print("수가 일치합니다.");
                        cnt++;
                    }
                    else
                    {
                        //print("일치하지 않습니다.");
                        continue;
                    }
                }

                txt.DOText("", 0);

                Sequence seq = DOTween.Sequence();
                switch (cnt)
                {

                    case 1:
                        //6
                        print("6등 상품 증정");
                        GameObject go = Instantiate(fireWork, pos, Quaternion.identity);
                        button.SetActive(false);
                        seq.Append(txt.DOText("6등 당첨되셨습니다.", 0.5f));
                        seq.AppendInterval(1f);
                        seq.AppendCallback(() =>
                        {
                            button.SetActive(true);
                            Destroy(go, 1f);
                            seq.Kill();
                        });
                        money.cullMoney += 1000;
                        break;
                    case 2:
                        //5
                        print("5등 상품 증정");
                        GameObject go1 = Instantiate(fireWork, pos, Quaternion.identity);
                        button.SetActive(false);
                        seq.Append(txt.DOText("5등 당첨되셨습니다.", 0.5f));
                        seq.AppendInterval(1f);
                        seq.AppendCallback(() =>
                        {
                            button.SetActive(true);
                            Destroy(go1, 1f);
                            seq.Kill();
                        });
                        money.cullMoney += 5000;
                        break;
                    case 3:
                        //4
                        print("4등 상품 증정");
                        GameObject go2 = Instantiate(fireWork, pos, Quaternion.identity);
                        button.SetActive(false);
                        seq.Append(txt.DOText("4등 당첨되셨습니다.", 0.5f));
                        seq.AppendInterval(1f);
                        seq.AppendCallback(() =>
                        {
                            button.SetActive(true);
                            Destroy(go2, 1f);
                            seq.Kill();
                        });
                        money.cullMoney += 10000;
                        break;
                    case 4:
                        //3
                        print("3등 상품 증정");
                        GameObject go3 = Instantiate(fireWork, pos, Quaternion.identity);
                        button.SetActive(false);
                        seq.Append(txt.DOText("3등 당첨되셨습니다.", 0.5f));
                        seq.AppendInterval(1f);
                        seq.AppendCallback(() =>
                        {
                            button.SetActive(true);
                            Destroy(go3, 1f);
                            seq.Kill();
                        });
                        money.cullMoney += 50000;
                        break;
                    case 5:
                        //2
                        print("2등 상품 증정");
                        GameObject go4 = Instantiate(fireWork, pos, Quaternion.identity);
                        button.SetActive(false);
                        seq.Append(txt.DOText("2등 당첨되셨습니다.", 0.5f));
                        seq.AppendInterval(1f);
                        seq.AppendCallback(() =>
                        {
                            button.SetActive(true);
                            Destroy(go4, 1f);
                            seq.Kill();
                        });
                        money.cullMoney += 100000;
                        break;
                    case 6:
                        //1
                        GameObject go5 = Instantiate(fireWork, pos, Quaternion.identity);
                        print("1등 상품 증정");
                        button.SetActive(false);
                        seq.Append(txt.DOText("1등 당첨되셨습니다.", 0.5f));
                        seq.AppendInterval(1f);
                        seq.AppendCallback(() =>
                        {
                            button.SetActive(true);
                            Destroy(go5, 1f);
                            seq.Kill();
                        });
                        money.cullMoney += 1000000;
                        break;
                    default:
                        Debug.Log("안타깝네요ㅠㅠ");
                        button.SetActive(false);
                        seq.Append(txt.DOText("아쉽지만 당첨되지 않으셨습니다.", 0.5f));
                        seq.AppendInterval(1f);
                        seq.AppendCallback(() =>
                        {
                            button.SetActive(true);
                            seq.Kill();
                        });
                        break;
                }

                print(cnt);
                moneyTxt.DOText($"{money.cullMoney}Myungji", 0.5f);
                curCount.DOText($"{data.LimitLottoCount - data.CurLottoCount}회 남음", 0.5f);
                FieldReset();
            }
        }
        else
        {
            txt.DOText("오늘 살 수 있는 제한을 넘으셨습니다.",0.5f);
            print("제한을 넘어서지마라 애송이 너는 아직 준비가 되지않았다. 내일 오렴^^");
        }
        JSON.SavePlayerDataToJson();
    }

    void FieldReset()
    {
        foreach(TMP_InputField IF in inputFields)
        {
            IF.text = "";
        }
    }

    public void ResetCount()
    {
        images.GetComponent<Animator>().SetTrigger("Start");
        JSON.SavePlayerDataToJson();
    }

    public void AudioPlay(int i)
    {
        audioSources[i].PlayOneShot(clip);
    }

    public void ResetCountAgree()
    {
        if(money.cullMoney - 10000 <= 0)
        {
            txt.DOText("돈이 부족합니다.",0.5f);
        }
        else
        {
            txt.DOText("", 0f);
            txt.DOText("횟수가 초기화 되었습니다.",0.5f);
            moneyTxt.DOText("", 0f);
            moneyTxt.DOText($"{money.cullMoney}Myungji",0.5f);
            money.cullMoney -= 10000;
            data.CurLottoCount = 0;
            curCount.text = $"{data.LimitLottoCount - data.CurLottoCount}회 남음";
        }
        JSON.SavePlayerDataToJson();
        OutTrigger();
    }

    public void OutTrigger()
    {
        images.GetComponent<Animator>().SetTrigger("Out");
    }

    public void TxtValueChanged(int id)
    {
        if (int.Parse(inputFields[id].text) >= 34)
        {
            //"잘못된 수 입력!" 출력하기
            inputFields[id].text = null;
            return;
        }
        else
        {
            inputNum[id] = int.Parse(inputFields[id].text);
        }
    }
    
    [ContextMenu("돈 추가")]
    public void AddMoney()
    {
        money.cullMoney += 50000;
    }

    public void Print()
    {
        foreach (int a in inputNum)
        {
            print(a);
        }
    }
}
