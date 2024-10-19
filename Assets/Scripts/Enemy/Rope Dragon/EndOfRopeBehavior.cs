using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRopeBehavior : MonoBehaviour
{
    [SerializeField]
    public Transform ropeEnd;
    [SerializeField]
    public Transform ropeStart;
    [SerializeField]
    public SpriteRenderer segmentSprite;
    public float MaxDistanceFromRope;
    [SerializeField] private float SmoothSpeedToRope;
    public bool isAtMaxReach;
    public int ropeSegments;
    private float MaxReachCompensation = 0.01f;

    public GameObject target;

    private float MaxReach;
    private float DistanceFromRopeStartToEnd;
    private float DistanceFromRopeEndToHand;

    private void Awake()
    {
        SetMaxReach();
    }
    public void SetMaxReach()
    {
        MaxReach = segmentSprite.localBounds.size.y * ropeSegments - MaxReachCompensation;
    }

    private void FixedUpdate()
    {
        DistanceFromRopeStartToEnd = Vector3.Distance(ropeStart.position, ropeEnd.position);
        if (DistanceFromRopeStartToEnd > MaxReach)
        {
            isAtMaxReach = true;
        }
        else if (DistanceFromRopeStartToEnd < MaxReach)
        {
            isAtMaxReach = false;
        }
        target.transform.position = ropeEnd.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(ropeStart.position, MaxReach);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ropeStart.position, ropeEnd.position);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(ropeStart.position, DistanceFromRopeStartToEnd);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ropeEnd.position, DistanceFromRopeEndToHand);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(ropeEnd.position, MaxDistanceFromRope);
    }
}
