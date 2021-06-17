using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody playerRB;
    
    
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float gravityModifier;

    protected bool isOnGround = true;



    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        Debug.Log(isOnGround);
    }
}
