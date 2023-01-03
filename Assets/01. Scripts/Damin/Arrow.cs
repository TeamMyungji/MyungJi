using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    private GameObject QuestPos;
    [SerializeField] private DeliveryMain GameManager;
    [SerializeField] private GameObject arrowmap;


    void Start()
    {
        // Mesh mesh = GetComponent<MeshFilter>().mesh;
        // mesh.triangles = mesh.triangles.Reverse().ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isDelivering)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            QuestPos = GameObject.FindGameObjectWithTag("QuestClear");
            transform.LookAt(QuestPos.transform);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
