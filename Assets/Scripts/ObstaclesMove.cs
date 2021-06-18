﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    [Range(0, 25)] [SerializeField] protected float obstaclesSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * obstaclesSpeed * Time.deltaTime);
    }
}
