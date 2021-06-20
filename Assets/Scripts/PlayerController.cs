using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool gameOver;

    protected int maxJumpTime = 0;

    protected Rigidbody playerRB;
    protected Animator playerAnimator;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    protected AudioSource playerAudio;
    public ParticleSystem pS;
    
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float gravityModifier;
   
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && maxJumpTime < 2)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 0.8f);
            maxJumpTime++;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            maxJumpTime = 0;
            playerRB.velocity = Vector3.zero;
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            playerRB.constraints &= RigidbodyConstraints.FreezeRotationX;
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            if (!pS.isPlaying) pS.Play();
            if (pS.isPlaying) pS.Stop();
            if (pS.isPlaying) pS.Stop();
            if (!pS.isPlaying) pS.Play();
            playerAudio.PlayOneShot(crashSound, 0.8f);
        }
    }


    void downFast()
    {
        if (playerRB.velocity.y <= -0.01f)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, -10f, playerRB.velocity.y);

        }
    }

    void speedUp()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = this.GetComponent<AudioSource>();
        playerRB = this.GetComponent<Rigidbody>();
        playerAnimator = this.GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        downFast();
        speedUp();
    }
}
