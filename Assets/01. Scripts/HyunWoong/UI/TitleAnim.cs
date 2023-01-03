using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Delay());
    }

    public void EndMove()
    {
        Animator anim = GameObject.Find("Title Image").GetComponent<Animator>();
        anim.SetTrigger("Start");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);

        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Start");
    }
}
