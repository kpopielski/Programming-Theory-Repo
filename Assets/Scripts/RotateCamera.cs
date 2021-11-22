using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float speed = 200;
    public GameObject player;
    
   
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(Vector3.down, speed * Time.deltaTime);
        }

        transform.position = player.transform.position;
    }
}
