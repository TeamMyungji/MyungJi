using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Delivery")]
public class DeliverySO : ScriptableObject
{
    public Vector3 deliveryLocation;
    public string deliveryName;
    public int allowance;
}
