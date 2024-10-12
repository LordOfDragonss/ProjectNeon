using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PlayerControls : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction walkAction;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        walkAction = playerInput.actions["Walk"];
        walkAction.ReadValue<float>();

        playerInput.SwitchCurrentControlScheme();
    }
    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("dde");
    }
}
