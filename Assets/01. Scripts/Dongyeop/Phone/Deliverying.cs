using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deliverying : MonoBehaviour
{
    private TextMeshProUGUI _deliveryPosText;
    private TextMeshProUGUI _timeRemainingText;
    private RectTransform _rectTransform;
    private float _deliveryTimeRemaining = 60;

    private void Awake() 
    {
        _deliveryPosText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _timeRemainingText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.anchoredPosition = new Vector3(350, 30, 0);
    }

    private void Update() 
    {
        if (DeliveryMain.instance.isDelivering)
        {
            _deliveryTimeRemaining -= Time.deltaTime;
            _timeRemainingText.text = string.Format("{0:0.#}", _deliveryTimeRemaining);

            if (_deliveryTimeRemaining < 0)
            {
                DeliveryMain.instance.isDelivering = false;
                DeliveryManager.instance.DeliveryButtonReset();
                DeliveryMain.instance.DeliveryFailed();
                _rectTransform.anchoredPosition = new Vector3(350, 30, 0);
            }
        }
    }

    public void DeliveryingStart(string deliveryPositionName)
    {
        _deliveryPosText.text = deliveryPositionName;
        _deliveryTimeRemaining = 60;
    }
}
