using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoliceMovement : MonoBehaviour
{
    private GameObject Player;

    [SerializeField] public float CopSpeed;

    [SerializeField] private float DistanceToPlayer;

    [SerializeField] private float ViewRadius;

    [SerializeField] private float ViewAngle;

    [SerializeField] private LayerMask PlayerMask;

    [SerializeField] private LayerMask ObstacleMask;

    [SerializeField] private List<Transform> VisibleTargets = new List<Transform>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        CopSpeed = 6.0f;
        
        FindObjectOfType<PlayerChaos>().PoliceList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, CopSpeed * Time.deltaTime);
        
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
