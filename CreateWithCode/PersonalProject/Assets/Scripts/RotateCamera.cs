using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
 private float forwardInput;
 private float speed = 200;
 private float Speed = 200;


    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
        
        forwardInput = Input.GetAxis("Vertical");
      

        transform.position = player.transform.position;
        
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * forwardInput);
}
}