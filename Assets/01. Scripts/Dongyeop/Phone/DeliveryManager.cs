using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager instance = null;

    [SerializeField] private DeliveryButton _deliveryButton1;
    [SerializeField] private DeliveryButton _deliveryButton2;
    [SerializeField] private DeliveryButton _deliveryButton3;

    private void Awake() 
    {
        instance = this;
    }
    
    public void DeliveryButtonReset()
    {
        if (_deliveryButton1 != null)
            _deliveryButton1.DeliveryReset();
        if (_deliveryButton2 != null)
        _deliveryButton2.DeliveryReset();
        if (_deliveryButton3 != null)
        _deliveryButton3.DeliveryReset();
    }
}
