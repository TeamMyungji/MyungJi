using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TutorialManager : MonoSingleton<TutorialManager>
{
    [Header("UI")]
    public RectTransform canvas;
    public TextMeshProUGUI tutoTxt;
    private Image panel;

    [Header("strings")]
    public List<string> messages = new List<string>();
    public string gameScene;

    [Header("Vectors")]
    public Vector2 backPos;
    public Vector2 txtAnchorPos;

    [Header("floats")]
    public float delay = 0.6f;

    [Header("Other Scripts")]
    public MoneySO money;
    public JSON json;
    public Animator[] interactionExplainUI;

    private bool _isMove = false;

    private void Awake()
    {
        _isMove = false;
        panel = canvas.Find("TutoPanel").GetComponent<Image>();
        StartCoroutine(UIAnim(interactionExplainUI, 0));
    }

    public void Tuto(int index)
    {
        _isMove = false;
        StartCoroutine(UIAnim(interactionExplainUI, index));
    }

    private IEnumerator UIAnim(Animator[] anim,int i)
    {
        if (anim.Length > i)
        {
            anim[i].SetTrigger("Start");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            anim[i].SetTrigger("Out");
        }

        HowToControUI(i);
    }
    private void TutoStart()
    {
        Sequence seq = DOTween.Sequence();
    }

    /// <summary>
    /// ���۹� ���� UI���� �Լ�
    /// </summary>
    public void HowToControUI(int id)
    {
        Sequence seq = DOTween.Sequence();
        tutoTxt.text = messages[id];
        _isMove = false;
        seq.Append(tutoTxt.rectTransform.DOAnchorPosY(canvas.rect.height/4, delay));
        seq.AppendInterval(3);
        seq.AppendCallback(() =>
        {
            _isMove = true;
            tutoTxt.rectTransform.DOAnchorPos(backPos,delay);
            seq.Kill();

            if (id == 2)
                StartCoroutine(TutoEnd());
        });
    }

    private IEnumerator TutoEnd()
    {
        yield return new WaitForSeconds(.25f);
        SceneLoader.Instance.LoadScene(gameScene);
        UIFadeController.instance.DissolveOn();
    }
}
