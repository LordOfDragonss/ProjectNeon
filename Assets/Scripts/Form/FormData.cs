using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "file", menuName = "Form")]
public class FormData : ScriptableObject
{
    [SerializeField] private FormType formType;
    [SerializeField] private AttackData upAttack;
    [SerializeField] private AttackData downAttack;
    [SerializeField] private AttackData sideAttack;
    [SerializeField] private AttackData naturalAttack;
}
