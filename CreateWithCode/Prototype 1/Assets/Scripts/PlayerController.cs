using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 25;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      horizontalInput = Input.GetAxis("Horizontal");
      forwardInput = Input.GetAxis("Vertical");

      // we move the vehicle forward 
    transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    // rotates the car based on horizontal Input
    transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
