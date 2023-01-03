using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _soundPanelGameObject;
    [SerializeField] private RectTransform _soundPanel;
    [SerializeField] private RectTransform _resolutionPanel;
    [SerializeField] private float _moveTime;

    private TitleUIManager _titleUIManager;
    private RectTransform _firstPanel;
    [HideInInspector] public RectTransform mainPanel;

    private bool _isPause = false;
    private bool _isMove = false;
    private bool _isSoundPanel = false;
    private bool _isResolutionPanel = false;

    private void Awake() 
    {
        _soundPanelGameObject.SetActive(false);

        mainPanel = GetComponent<RectTransform>();
        _firstPanel = transform.Find("First_Panel").GetComponent<RectTransform>();
        _titleUIManager = GameObject.Find("ButtonSelect").GetComponent<TitleUIManager>();
    }
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isMove)
        {
            if (_isSoundPanel)
            {
                _isMove = true;

                Sequence seq = DOTween.Sequence();
                seq.Append(_soundPanel.DOAnchorPosX(_soundPanel.anchoredPosition.x + -1920, _moveTime));
                seq.OnComplete(() =>
                {
                    _isSoundPanel = false;
                    _isMove = false;
                });
            }
            else if (_isResolutionPanel)
            {
                _isMove = true;

                Sequence seq = DOTween.Sequence();
                seq.Append(_resolutionPanel.DOAnchorPosY(_resolutionPanel.anchoredPosition.y + -1080, _moveTime));
                seq.OnComplete(() =>
                {
                    _isResolutionPanel = false;
                    _isMove = false;
                });
            }
            else if (_isPause)
                PauseMenuMoveY(_firstPanel, -1080);
        }
    }

    public void SoundButtonClick()
    {
        if (_isMove)
            return;
        print(1);
        _isMove = true;

        Sequence seq = DOTween.Sequence();
        seq.Append(_soundPanel.DOAnchorPosX(_soundPanel.anchoredPosition.x + 1920, _moveTime));
        seq.OnComplete(() =>
        {
            _isSoundPanel = true;
            _isMove = false;
        });
    }

    public void ResolutionButtonClick()
    {
        if (_isMove)
            return;
        print(2);
        _isMove = true;

        Sequence seq = DOTween.Sequence();
        seq.Append(_resolutionPanel.DOAnchorPosY(_resolutionPanel.anchoredPosition.y + 1080, _moveTime));
        seq.OnComplete(() =>
        {
            _isResolutionPanel = true;
            _isMove = false;
        });
    }

    public void PauseMenuMoveX(RectTransform rectTransform, int movePos)
    {
        _isMove = true;

        if (_isPause)
            _soundPanelGameObject.SetActive(false);

        Sequence seq = DOTween.Sequence();
        seq.Append(rectTransform.DOAnchorPosX(rectTransform.anchoredPosition.x + movePos, _moveTime));
        seq.OnComplete(() =>
        {
            if (_isPause)
            {
                _isMove = false;
                _isPause = false;
                _titleUIManager.isInput = false;
            }
            else if (!_isPause)
                PauseMenuMoveY(_firstPanel, 1080);
        });
    }

    private void PauseMenuMoveY(RectTransform rectTransform, int movePos)
    {
        _isMove = true;

        Sequence seq = DOTween.Sequence();
        seq.Append(rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + movePos, _moveTime));
        seq.OnComplete(() =>
        {
            if (_isPause)
                PauseMenuMoveX(mainPanel, 1920);
            else if (!_isPause)
            {
                _soundPanelGameObject.SetActive(true);
                _isMove = false;
                _isPause = true;
            }
        });
    }
}
