using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    protected bool isOnGround = true;
    public bool gameOver;
    
    protected Rigidbody playerRB;
    protected Animator playerAnimator;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    protected AudioSource playerAudio;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float gravityModifier;
    public ParticleSystem collideParticle;


    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 0.8f);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            if (!collideParticle.isPlaying)
            {
                collideParticle.Play();
            }
        playerAudio.PlayOneShot(crashSound, 0.8f);
        }
     }

    
    void SetAnimation()
    {

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
    }
}
