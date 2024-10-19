using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerDetection ChaseDetector;
    public PlayerDetection AttackDetector;
    private Rigidbody2D rb;
    public float speed;

    public EnemyPatrol EnemyPatrol;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void FixedUpdate()
    {
        if (ChaseDetector.PlayerDetected)
        {
            if (EnemyPatrol.IsGrounded())
            {

                MoveTowards(ChaseDetector.target);
                EnemyPatrol.isPatroling = false;
                if (AttackDetector.PlayerDetected)
                {
                    Attack();
                }
            }
            else
            {
                rb.velocity = new Vector2(0,rb.velocity.y);
            }
        }
        else
        {
            EnemyPatrol.isPatroling = true;
        }
    }

    public void MoveTowards(GameObject target)
    {
        // Keep the enemy's current Y position to prevent vertical movement
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }
}
