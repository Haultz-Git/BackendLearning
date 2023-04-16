using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaeyermove : MonoBehaviour
{
    Vector2 inputVector;
    [SerializeField] private float moveSpeed;
    PlayerInput playerInput;

    public event Action OnJumpPressed;
    private void Start()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.Jump.performed += Jump_performed;

    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Jump();
    }

    private void Update()
    {
        inputVector = playerInput.Player.WSADmovement.ReadValue<Vector2>();
        //if (Input.GetKey(KeyCode.A))
        //{
        //    inputVector.x = -1;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    inputVector.y = -1;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    inputVector.y = 1;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    inputVector.x = 1;
        //}
        inputVector = inputVector.normalized;
        Debug.Log(inputVector);
        Vector3 moveDirection = new Vector3(inputVector.x, 0f,inputVector.y);
        transform.position = transform.position + moveDirection *Time.deltaTime*moveSpeed;
            
    }

    private void Jump()
    {
        Debug.Log("Jumping");
    }
}
