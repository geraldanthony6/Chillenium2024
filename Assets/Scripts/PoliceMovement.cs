using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoliceMovement : MonoBehaviour
{
    private GameObject Player;

    [SerializeField] private Transform[] WanderPoints;

    [SerializeField] private Transform CurrentWanderPoint;

    [SerializeField] private int CurrentWanderIndex;

    [SerializeField] private float DistanceToPlayer;

    [SerializeField] private float ViewRadius;

    [SerializeField] private float ViewAngle;

    [SerializeField] private LayerMask PlayerMask;

    [SerializeField] private LayerMask ObstacleMask;

    [SerializeField] private List<Transform> VisibleTargets = new List<Transform>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentWanderIndex = 0;
        CurrentWanderPoint = WanderPoints[CurrentWanderIndex];
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, CurrentWanderPoint.position);
        if (DistanceToPlayer > 1.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position ,CurrentWanderPoint.position, 2.0f * Time.deltaTime);
        }

        if (DistanceToPlayer <= 1.0f && CurrentWanderIndex != WanderPoints.Length - 1)
        {
            CurrentWanderIndex++;
            CurrentWanderPoint = WanderPoints[CurrentWanderIndex];
        } else if (DistanceToPlayer <= 1.0f && CurrentWanderIndex == WanderPoints.Length - 1)
        {
            CurrentWanderIndex = 0;
            CurrentWanderPoint = WanderPoints[CurrentWanderIndex];
        }
        
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, ViewRadius, PlayerMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.forward, dirToTarget) < ViewAngle / 2)
            {
                float distToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, dirToTarget, distToTarget, ObstacleMask))
                {
                    VisibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    
    
}
