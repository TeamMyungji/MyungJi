using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoTrigger : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private GameObject _previousGMO;
    private TutorialManager _tutorialManager;
    private bool _isTirgger = false;

    private void Awake()
    {
        _tutorialManager = GameObject.Find("GameManager").GetComponent<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isTirgger)
        {
            _isTirgger = true;
            _tutorialManager.Tuto(_index);
            _previousGMO?.SetActive(false);
        }
    }
}
