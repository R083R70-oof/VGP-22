using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
  private float speed = 10.0f;
    private float horizontalInput;
    private float forwardInput;
     private Rigidbody playerRb;
     public float gravityModifier;
      public GameObject projectilePrefab;
    private float turnSpeed = 50.0f;


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
         playerRb.AddForce(Vector3.up * 80, ForceMode.Impulse);
      }

       if (Input.GetKeyDown(KeyCode.E))
      {
         playerRb.AddForce(Vector3.forward * 50, ForceMode.Impulse);
      }

      // we move the vehicle forward 
    transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    // rotates the car based on horizontal Input
    transform.Rotate(Vector3.up, turnSpeed * forwardInput * Time.deltaTime);
    }
}
