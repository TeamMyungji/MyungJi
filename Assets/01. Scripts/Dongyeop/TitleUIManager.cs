using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private string _tutoScene;
    [SerializeField] private string _gameScene;
    [SerializeField] private string _startScene;
    [SerializeField] private float _movePosition = 125;
    [SerializeField] private float _moveTime;
    [SerializeField] private JSON _json;
    private Data _data;
    private PausePanel _pausePanel;
    private RectTransform _thisSelectText;
    public MoneySO money;
    private int _thisPos = 3;
    public bool _isMove = false;
    public bool isInput = false;

    private void Awake() 
    {
        _json.LoadPlayerDataToJson();
        _data = _json.playerData;
        _thisSelectText = transform.GetChild(0).GetComponent<RectTransform>();
        _pausePanel = GameObject.Find("PausePanel").GetComponent<PausePanel>();
    }

    private IEnumerator Start() 
    {
        yield return new WaitForSeconds(3f);
        _isMove = false;
        isInput = false;
    }

    private void Update() 
    {
        this.enabled = true;
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && !_isMove)
            SelectTextMove(_movePosition, 1);
        else if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && !_isMove)
            SelectTextMove(-_movePosition, -1);

        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Space))
            TextSelect();
    }

    private void SelectTextMove(float movePos, int move)
    {
        if ((_thisPos <= 0 && movePos < 0) || (_thisPos >= 3 && movePos > 0))
            return;

        _isMove = true;
        Sequence seq = DOTween.Sequence();
        seq.Append(_thisSelectText.DOAnchorPosY(_thisSelectText.anchoredPosition.y + movePos, _moveTime));
        seq.OnComplete(() =>
        {
            _thisPos += move;
            _isMove = false;
        });
    }

    private void TextSelect()
    {
        if (_isMove)
            return;

        switch (_thisPos)
        {
            case 3:
                isInput = true;
                money.cullMoney = 0;
                money.cullDebt = 50000;
                SceneLoader.Instance.LoadScene(_tutoScene);
                UIFadeController.instance.DissolveOn();
                break;
            case 2:
                if (money.cullDebt <= 0)
                    return;
                isInput = true;
                SceneLoader.Instance.LoadScene(_gameScene);
                UIFadeController.instance.DissolveOn();
                break;
            case 1: 
                if (isInput)
                    return;

                isInput = true;
                _pausePanel.PauseMenuMoveX(_pausePanel.mainPanel, -1920);
                break;
            case 0:
                isInput = true;
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
                break;
        }
    }
}
