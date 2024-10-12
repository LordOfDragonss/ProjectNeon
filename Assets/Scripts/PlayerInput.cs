using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 _moveDirection;

    public InputAction inputActionReference;

}
