using System.Collections;
using System.Collections.Generic;
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

    [Header("Movement Settings")]
    public float movementSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 10f;
    public int maxJumps = 2;

    private int jumpCount;

    private void FixedUpdate()
    {
        ResetJumpCount();

        rb.velocity = new Vector2(inputVector.x * movementSpeed, rb.velocity.y);
    }

    #region Move
    public void Move(InputAction.CallbackContext context)
    {
        inputVector.x = context.ReadValue<Vector2>().x;

        HandleRotationOnMoving(inputVector.x);
    }
    #endregion

    #region Rotation

    private void HandleRotationOnMoving(float inputValue)
    {
        if (inputValue > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputValue < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    #endregion
    #region Jump
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpCount < maxJumps)
        {
            ExecuteJump((float)context.duration);
        }
    }
    private void ExecuteJump(float jump)
    {
        if (CheckJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * jumpForce);
            jumpCount++;
        }
    }   
    private bool CheckJump()
    {
        return jumpCount < maxJumps - 1;
    }
    private void ResetJumpCount()
    {
        if (IsGrounded())
        {
            jumpCount = 0;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    #endregion  
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        }
    }

}
