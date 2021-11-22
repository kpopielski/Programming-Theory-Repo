using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    private Rigidbody friendRB;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        friendRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Roman");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        friendRB.AddForce(lookDirection*-1 * speed);
    }
}
