using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
  private float speed = 5.0f;
    private float Speed = 10;
    private float horizontalInput;
    private float forwardInput;
     private Rigidbody playerRb;
     public float gravityModifier;
      public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
      horizontalInput = Input.GetAxis("Horizontal");
      forwardInput = Input.GetAxis("Vertical");
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
         playerRb.AddForce(Vector3.up * 30, ForceMode.Impulse);
      }

       if (Input.GetKeyDown(KeyCode.E))
      {
         playerRb.AddForce(Vector3.forward * 50, ForceMode.Impulse);
      }

      // we move the vehicle forward 
    transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    // rotates the car based on horizontal Input
    transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * Speed);
    }
}
