using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    public Vector3 Move(GameObject player)
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        return lookDirection;
    }
    public virtual int FoodPoints(int points)
    {
        return points;
    }
}
