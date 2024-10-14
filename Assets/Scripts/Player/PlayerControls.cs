using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerInput playerInput;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector2 inputVector;

    public float movementSpeed = 5f;
    public float jumpHeight = 10f;
    
    private void Update()
    {
        rb.velocity = inputVector;
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputVector.x = context.ReadValue<Vector2>().x * movementSpeed;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        inputVector.y = context.ReadValue<Vector2>().y * jumpHeight;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
