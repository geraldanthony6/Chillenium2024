using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour
{
    private GameObject Player;
    
    [SerializeField] private Transform[] WanderPoints;

    [SerializeField] private Transform CurrentWanderPoint;

    [SerializeField] private int CurrentWanderIndex;

    [SerializeField] private float DistanceToTargetPoint;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWanderIndex = 0;
        CurrentWanderPoint = WanderPoints[CurrentWanderIndex];
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTargetPoint = Vector2.Distance(transform.position, CurrentWanderPoint.position);
        if (DistanceToTargetPoint > 1.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position ,CurrentWanderPoint.position, 2.0f * Time.deltaTime);
        }

        if (DistanceToTargetPoint <= 1.0f && CurrentWanderIndex != WanderPoints.Length - 1)
        {
            CurrentWanderIndex++;
            CurrentWanderPoint = WanderPoints[CurrentWanderIndex];
        } else if (DistanceToTargetPoint <= 1.0f && CurrentWanderIndex == WanderPoints.Length - 1)
        {
            CurrentWanderIndex = 0;
            CurrentWanderPoint = WanderPoints[CurrentWanderIndex];
        }

    }
}
