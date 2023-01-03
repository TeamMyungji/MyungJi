using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMain : MonoBehaviour
{
    public static DeliveryMain instance = null;

    [SerializeField] private GameObject _clearObj;
    private RectTransform _deliveryingPage;

    [SerializeField] private float _posY = -72;
    private float _posX;
    private float _posZ;

    public bool isDelivering = false;

    private void Awake()
    {
        instance = this;
        _deliveryingPage = GameObject.Find("DeliveryingPage").GetComponent<RectTransform>();
    }

    public void DeliveryButtonClick(float posX, float posZ, string deliveryPosition)
    {
        _deliveryingPage.GetComponent<Deliverying>().DeliveryingStart(deliveryPosition);
        isDelivering = true;
        _deliveryingPage.anchoredPosition = new Vector3(0, 30, 0);
        _posX = posX;
        _posZ = posZ;
        DeliveryPositionSpawn();
    }
    GameObject go;
    private void DeliveryPositionSpawn()
    {
        go = Instantiate(_clearObj, new Vector3(_posX, _posY, _posZ), Quaternion.identity);
    }

    public void DeliveryFailed()
    {
        Destroy(go);
    }
}
