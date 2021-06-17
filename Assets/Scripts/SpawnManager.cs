using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected GameObject ObstaclePrefabs;

    void spawnObstacle()
    {
        Vector3 spawnPos = new Vector3(25, 0, 0);
        Instantiate(ObstaclePrefabs, spawnPos, ObstaclePrefabs.transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacle", 0.21f, 0.21f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
