using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class DynamicRope : MonoBehaviour
{
    [SerializeField] private GameObject RopeStart;
    [SerializeField] private GameObject RopeEnd;
    public int NumberOfSegments;
    public GameObject[] SegmentsPrefabs;

    public EndOfRopeBehavior endBehavior;

    public Solver2D solver;

    public float spriteSizePercentage;

    private void Start()
    {
        SetupEndBehavior();
        GenerateRope();
    }

    public void SetupEndBehavior()
    {
        endBehavior.ropeSegments = NumberOfSegments;
        endBehavior.ropeStart = RopeStart.transform;
        //endBehavior.ropeEnd = RopeEnd.transform;
        endBehavior.segmentSprite = SegmentsPrefabs[0].GetComponent<SpriteRenderer>();
        endBehavior.SetMaxReach();
    }

    public void GenerateRope()
    {
        GameObject parent = RopeStart;
        for (int i = 0; i < NumberOfSegments; i++)
        {
            
            GameObject segment = Instantiate(SegmentsPrefabs[0],parent.transform);
            if(i != 0)
            segment.transform.position += new Vector3(0, -spriteSizePercentage);
            parent = segment;
        }
        RopeEnd.transform.parent = parent.transform;
        RopeEnd.transform.position = parent.transform.position + new Vector3(0, -spriteSizePercentage);
        IKChain2D chain = solver.GetChain(0);
        chain.transformCount = NumberOfSegments + 1;
        chain.effector = RopeEnd.transform;
        solver.UpdateIK(1);
    }
}
