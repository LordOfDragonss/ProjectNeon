using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;


[CreateAssetMenu(menuName = "Attack")]

public abstract class AttackData : ScriptableObject
{
    [SerializeField] public string animationName;
    [SerializeField] public int damage;
    public virtual void PerformAttack(Animator animator) 
    { 
        animator.Play(animationName);
    }
}
