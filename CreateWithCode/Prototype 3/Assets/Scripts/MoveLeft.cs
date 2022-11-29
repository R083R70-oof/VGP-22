using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{     
    private float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerControllerScript.gameOver == false)
      {
      transform.Translate(Vector3.left * Time.deltaTime * speed);
      }
    }
}
