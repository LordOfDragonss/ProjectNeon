using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] AttackData attackData;
    [SerializeField] Animator animator;

    public void PerformAttack(string attackType)
    {
        attackData.PerformAttack(animator, attackType);
        StartCoroutine(ActivateAttack());
    }

    private IEnumerator ActivateAttack()
    {
        if(attackData.colliders.Count >= 2) 
        { 
            for(int i = 0; i < attackData.colliders.Count; i++)
            {
                attackData.colliders[i].enabled = true;
                yield return new WaitForSeconds(0.1f);
                attackData.colliders[i].enabled = false;
            }
        }
        else
        {
            attackData.colliders[0].enabled = true;
        }
        
        yield return null;
    }
}
