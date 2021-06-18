using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    [Range(-40, 0f)] [SerializeField] protected float rightBound;
    protected Vector3 firstPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        firstPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x <= rightBound)
        {
            this.transform.position = firstPosition;
        }
    }
}
