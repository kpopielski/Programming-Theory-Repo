using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : Food
{
    private Rigidbody friendRB;
    private GameObject player;
    public float speed;
   public int friendPoints;
    // Start is called before the first frame update
    void Start()
    {
        friendRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Roman");
        friendPoints = FoodPoints(100);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection =  Move(player);
        friendRB.AddForce(lookDirection*-1 * speed);
    }
    
}
