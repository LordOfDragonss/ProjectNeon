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
    [SerializeField] Rigidbody2D rb;    
    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("dde");
    }
}
