using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour
{
    private GameObject Player;
    
    [SerializeField] private Transform[] WanderPoints;
    
    [SerializeField] private Transform[] GetManagerRoute;

    [SerializeField] private Transform CurrentWanderPoint;

    [SerializeField] private Transform CurrentManagerRoutePoint;

    [SerializeField] private int CurrentWanderIndex;
    
    [SerializeField] private int CurrentManagerRouteIndex;

    [SerializeField] private float DistanceToTargetPoint;

    [SerializeField] private ShopperBrain Brain;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWanderIndex = 0;
        CurrentWanderPoint = WanderPoints[CurrentWanderIndex];

        CurrentManagerRouteIndex = 0;
        CurrentManagerRoutePoint = GetManagerRoute[CurrentManagerRouteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (!Brain.GetIsPissed())
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
        else if(Brain.GetIsPissed())
        {
            DistanceToTargetPoint = Vector2.Distance(transform.position, CurrentManagerRoutePoint.position);
            if (DistanceToTargetPoint > 1.0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, CurrentManagerRoutePoint.position,
                    4.0f * Time.deltaTime);
            }

            if (DistanceToTargetPoint <= 1.0f && CurrentManagerRouteIndex != GetManagerRoute.Length - 1)
            {
                CurrentManagerRouteIndex++;
                CurrentManagerRoutePoint = GetManagerRoute[CurrentManagerRouteIndex];
            }
            else if (DistanceToTargetPoint <= 1.0f && CurrentManagerRouteIndex == GetManagerRoute.Length - 1)
            {
                Debug.Log("Spawn Police");
                Destroy(gameObject);
            }
        }


    }
}
