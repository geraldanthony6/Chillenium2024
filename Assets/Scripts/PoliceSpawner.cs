using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PolicePrefab;

    [SerializeField] private Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPolice()
    {
        Instantiate(PolicePrefab, transform.position, Quaternion.identity);
    }
}
