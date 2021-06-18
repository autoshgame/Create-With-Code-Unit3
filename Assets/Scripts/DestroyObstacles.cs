using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{

    [SerializeField] protected float leftBound = -1.18f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x < leftBound)
        {
            Destroy(this.gameObject);
        }
    }
}
