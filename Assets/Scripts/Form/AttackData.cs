using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;


[CreateAssetMenu(menuName = "Attack")]

public abstract class AttackData : ScriptableObject
{
    [SerializeField] public string animationName;
    [SerializeField] public int damage;
    [SerializeField] public List<Collider2D> colliders;
    public virtual void PerformAttack(Animator animator, string attackType) 
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = false;
        }
        animator.Play(animationName);
    }

    
}
