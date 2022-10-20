using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;

    private float moveH;
    private float moveV;
    private float moveY;

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        if (characterController.isGrounded)
        {
            moveY = 0f;
        }
        else
        {
            moveY += Physics.gravity.y * Time.deltaTime;
        }
        Vector3 moveVec = (transform.right * moveH + transform.forward * moveV) * moveSpeed;
        moveVec.y = moveY;  
        characterController.Move(moveVec * Time.deltaTime);
    }
}
