using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "file", menuName = "Form")]
public class FormData : ScriptableObject
{
    [SerializeField] private FormType formType;
    [SerializeField] private Attack upAttack;
    [SerializeField] private Attack downAttack;
    [SerializeField] private Attack sideAttack;
    [SerializeField] private Attack naturalAttack;
}
