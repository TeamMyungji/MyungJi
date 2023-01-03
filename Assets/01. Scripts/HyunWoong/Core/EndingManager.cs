using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EndingManager : MonoBehaviour
{
    public TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();

        StartCoroutine(Delay(1f));
    }

    private IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        txt.rectTransform.DOAnchorPosY(0, delayTime+1);
    }
}
