using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public enum DetectionMode
    {
        Box, Circle
    }

    [field: SerializeField]
    public bool PlayerDetected { get; private set; }
    public DetectionMode detectionMode;
    public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;

    [Header("OverlapBox Parameters")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.one;
    public float detectorRadius = 1f;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float detectionDelay = 0.3f;

    public LayerMask detectorLayerMask;

    public GameObject target;

    [Header("Gizmo paramters")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetectedColor = Color.red;
    public bool showGizmos = true;

    public void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }

    public void PerformDetection()
    {
        Collider2D collider = GetCollider();
        if (collider != null)
        {
            PlayerDetected = true;
            target = collider.gameObject;
        }
        else
        {
            PlayerDetected = false;
            target = null;
        }

    }

    public Collider2D GetCollider()
    {
        switch (detectionMode)
        {
            case DetectionMode.Box:
                return Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);
            case DetectionMode.Circle:
                return Physics2D.OverlapCircle((Vector2)detectorOrigin.position + detectorOriginOffset, detectorRadius, detectorLayerMask);
            default:
                return Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);
        }

    }

    public void OnDrawGizmos()
    {
        if (showGizmos && detectorOrigin != null)
        {
            Gizmos.color = gizmoIdleColor;
            if (PlayerDetected)
                Gizmos.color = gizmoDetectedColor;
            switch (detectionMode)
            {
                case DetectionMode.Box:
                    Gizmos.DrawWireCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
                    break;
                case DetectionMode.Circle:
                    Gizmos.DrawWireSphere(detectorOrigin.position, detectorRadius);
                    break;
            }
        }
    }
}
