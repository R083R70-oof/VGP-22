using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource PlayerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
      {
         playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
         isOnGround = false;
         playerAnim.SetTrigger("Jump_trig");
         dirtParticle.Stop();
         PlayerAudio.PlayOneShot(jumpSound, 1.0f);
      }  
      
      if(Input.GetKeyDown(KeyCode.S))
      {
         playerRb.AddForce(Vector3.down * 10, ForceMode.Impulse);
         
      } 

    }
    private void OnCollisionEnter(Collision collision)
    
    { if (collision.gameObject.CompareTag("Ground"))
       
     {
       isOnGround = true;
     }
     else if(collision.gameObject.CompareTag("Obstacle"))
     {
      Debug.Log("Game Over");
      gameOver = true;
      playerAnim.SetBool("Death_b", true);
      playerAnim.SetInteger("DeathType_int", 1);
      explosionParticle.Play();
      dirtParticle.Stop();
      PlayerAudio.PlayOneShot(crashSound, 1.0f);
     }
    }
}

