using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public LayerMask WallLayers;

    public Transform groundCheck;
    public Transform WallCheck;
    public bool isPatroling;

    public bool isFacingRight = true;

    RaycastHit2D hitGround;
    RaycastHit2D hitWall;

    private void Update()
    {
        hitGround = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
        hitWall = Physics2D.Raycast(WallCheck.position, transform.right, 0.1f, WallLayers);
    }

    private void FixedUpdate()
    {
        if (isPatroling)
        {
            if (hitWall.collider)
            {
                isFacingRight = !isFacingRight;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (hitGround.collider)
            {
                if (isFacingRight)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
            }
            else
            {
                isFacingRight = !isFacingRight;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    public bool IsGrounded()
    {
        return hitGround.collider != null;
    }
}
