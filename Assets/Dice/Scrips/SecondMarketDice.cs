using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMarketDice : MonoBehaviour
{
    public bool SecondDice;
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public int moveTimer;
    public GameObject Camera;
    bool Throwable;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    public void Update()
    {
        SecondDice = Camera.GetComponent<cameracontroller>().SecondDice;

        if (SecondDice)
        {
            if (moveTimer == 0)
            {
                Throwable = true;
                transform.position = new Vector3(2, 5, 10);
                moveTimer++;
            }
        }
    }  
    
    public void Throw()
        {
            if (Throwable)
            {
                diceVelocity = rb.velocity;

                float dirX = UnityEngine.Random.Range(0, 1000);
                float dirY = UnityEngine.Random.Range(0, 1000);
                float dirZ = UnityEngine.Random.Range(0, 1000);
                transform.position = new Vector3(2, 5, 10);
                transform.rotation = UnityEngine.Random.rotation;
                rb.AddForce(transform.up * 500);
                rb.AddTorque(dirX, dirY, dirZ);
            }
        }

}
