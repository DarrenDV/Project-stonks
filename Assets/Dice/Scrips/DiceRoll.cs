using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public bool secondDice;
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public int moveTimer;
    //public GameObject Camera;
   // public bool throwable;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void Update()
    {
        //secondDice = Camera.GetComponent<cameracontroller>().secondDice;
        //Checks if the second marketdice is throwable
        // if (secondDice)
        // {
        //     if (moveTimer == 0)
        //     {
        //         throwable = true;
        //         transform.position = new Vector3(2, 5, 10);
        //         moveTimer++;
        //     }
        // }
    }  
    
    public void Throw()
    {
        // if (throwable)
        // {
            diceVelocity = rb.velocity;

            //Makes random dirs for the torque
            float dirX = UnityEngine.Random.Range(0, 1000);
            float dirY = UnityEngine.Random.Range(0, 1000);
            float dirZ = UnityEngine.Random.Range(0, 1000);

            //Standard position for the die
            transform.position = new Vector3(2, 5, 10);

            transform.rotation = UnityEngine.Random.rotation;
            //rb.AddForce(transform.up * 500);
            //rb.AddTorque(dirX, dirY, dirZ);
        //}
    }
}
