using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] AttackData attackData;
    [SerializeField] Animator animator;

    private void PerformAttack()
    {
        attackData.PerformAttack(animator);
        StartCoroutine(ActivateAttack());
    }

    private IEnumerator ActivateAttack()
    {
        yield return null;
    }
}
