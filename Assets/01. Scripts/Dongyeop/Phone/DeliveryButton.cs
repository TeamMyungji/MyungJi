using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryButton : MonoBehaviour
{
    [SerializeField] private List<DeliveryPosSO> _deliveryPosSO;
    private TextMeshProUGUI _text;
    private int _deliveryPosIndex;

    private void Awake() 
    {
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Start() 
    {
        DeliveryReset();
    }

    public void DeliveryReset()
    {
        _deliveryPosIndex = Random.Range(0, (_deliveryPosSO.Count - 1));
        _text.text = _deliveryPosSO[_deliveryPosIndex].positionName;
    }

    public void DeliveryButtonClick()
    {
        if (DeliveryMain.instance.isDelivering)
            return;
        
        DeliveryMain.instance.DeliveryButtonClick(_deliveryPosSO[_deliveryPosIndex].posX, _deliveryPosSO[_deliveryPosIndex].posZ, _deliveryPosSO[_deliveryPosIndex].positionName);
    }
}
