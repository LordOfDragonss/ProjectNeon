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

    private Vector2 inputVector;

    public float movementSpeed = 5f;
    
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

    }
}
