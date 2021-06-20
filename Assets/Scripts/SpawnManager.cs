using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    protected float startTime = 2f;
    protected float delayTime = 2f;
    
    [SerializeField] protected GameObject[] ObstaclePrefabs;
    [SerializeField] protected PlayerController playerControllerScript;

    
    void spawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            int obstacleIndex = Random.Range(0, ObstaclePrefabs.Length - 1);
            Vector3 spawnPos = new Vector3(25, 0, 0);
            Instantiate(ObstaclePrefabs[obstacleIndex], spawnPos, ObstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacle", 4f, 4f);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        startTime = Random.Range(0f, 1.5f);
        delayTime = Random.Range(0f, 1.5f);
    }
}
