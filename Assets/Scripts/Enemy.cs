using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Food
{
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed;
    public int enemyPoints;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Roman");
        enemyPoints = FoodPoints(300);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = Move(player);
        enemyRB.AddForce(lookDirection * speed);

        
        
          
        

    }
    

}
