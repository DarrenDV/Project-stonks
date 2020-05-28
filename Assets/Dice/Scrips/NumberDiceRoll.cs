using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDiceRoll : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    public void Start()
    {
        //Gets the RigidBody from the Dice
        rb = GetComponent<Rigidbody>();
    }

    public void Throw()
    {
        diceVelocity = rb.velocity;

        //Makes random dirs for the torque
        float dirX = UnityEngine.Random.Range(0, 100);
        float dirY = UnityEngine.Random.Range(0, 100);
        float dirZ = UnityEngine.Random.Range(0, 100);

        //Standard position for the die
        transform.position = new Vector3(0, 5, 11);

        transform.rotation = UnityEngine.Random.rotation;
        rb.AddForce(transform.up * 500);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
