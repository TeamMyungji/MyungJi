using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MonoSingleton<T> : MonoBehaviour//이거 쓰라고 말하기
{
    private static T instance;
    public static T Instance
    {
        get
        {
            try
            {
                instance = GameObject.Find("GameManager").GetComponentInChildren<T>();//GameManager라는 오브젝트의 자식 중 T의 스크립트를 가져와서 instance에 넣어줌
            }
            catch (NullReferenceException)
            {
                Debug.LogError($"Multiple instance is running{instance}");//instance가 여러개면 에러문구 띄워줌
            }

            return instance;//instance를 반환하여 사용 가능하게 해줌
        }
    }
}
