using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleMove : MonoBehaviour
{
    [SerializeField]
    private Vector2 moveToPos;
    public RectTransform pos;

    public void MoveTo()
    {
        pos.DOAnchorPos(moveToPos, 0.5f);
    }
}
