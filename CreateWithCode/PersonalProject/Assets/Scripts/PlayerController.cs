using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
     private Rigidbody playerRb;
     public float gravityModifier;
     public bool isOnGround = true;
    public bool gameOver = false;


    // Start is called before the first frame updat

    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
       Physics.gravity *= gravityModifier; 
       
    }

    // Update is called once per frame
    void Update()
     {
      if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
      {
         playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
         isOnGround = false;
      }
      
      horizontalInput = Input.GetAxis("Horizontal");
      forwardInput = Input.GetAxis("Vertical");
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
         playerRb.AddForce(Vector3.up * 60, ForceMode.Impulse);
      }

       if (Input.GetKeyDown(KeyCode.E))
      {
         playerRb.AddForce(Vector3.forward * 50, ForceMode.Impulse);
      }
 
   
      transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

      transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

   private void OnCollisionEnter (Collision collision)
   {
      if (collision.gameObject.CompareTag("Enemy"))
      {
         Debug.Log("Player has collided with enemy.");
      }
   }
   private void OnTriggerEnter (Collider other)  
   {
      if (other.gameObject.CompareTag("PowerUp"))
      {
         Destroy(other.gameObject);
      }
   } 
   
}
