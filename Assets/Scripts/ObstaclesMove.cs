using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    [Range(0, 25)] [SerializeField] protected float obstaclesSpeed;

    protected PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControllerScript.gameOver)
        {
            this.transform.Translate(Vector3.left * obstaclesSpeed * Time.deltaTime);
        }
    }
}
