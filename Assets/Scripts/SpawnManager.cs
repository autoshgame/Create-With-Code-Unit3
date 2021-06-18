using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected GameObject ObstaclePrefabs;
    protected float startTime = 2f;
    protected float delayTime = 2f;
    void spawnObstacle()
    {
        Vector3 spawnPos = new Vector3(25, 0, 0);
        Instantiate(ObstaclePrefabs, spawnPos, ObstaclePrefabs.transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacle", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        startTime = Random.Range(0f, 2f);
        delayTime = Random.Range(0f, 2f);
    }
}
