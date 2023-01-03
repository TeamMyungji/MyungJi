//지우셈

/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _Controller;
    [SerializeField] private float _speed = 5f;

    Vector3 moveDir;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDir = new Vector3(h * _speed, moveDir.y, v * _speed);

        moveDir = transform.TransformDirection(moveDir);

        _Controller.Move(moveDir * Time.deltaTime);
    }
}
 */