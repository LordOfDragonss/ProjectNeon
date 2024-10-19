using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
    private bool isJumping;

    public float movementSpeed = 5f;
    public float jumpHeight = 10f;
    
    private void Update()
    {
        rb.velocity = inputVector;

        if (isJumping)
        {
            if (IsGrounded()) isJumping = false;
            inputVector.y -= 0.1f;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputVector.x = context.ReadValue<Vector2>().x * movementSpeed;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            isJumping = true;
            inputVector.y = context.ReadValue<Vector2>().y * jumpHeight;
        }
    }

    private bool IsGrounded()
    {
        print("fe");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
