using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketDiceRoll : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Throw()
    {
        diceVelocity = rb.velocity;

        float dirX = UnityEngine.Random.Range(0, 100);
        float dirY = UnityEngine.Random.Range(0, 100);
        float dirZ = UnityEngine.Random.Range(0, 100);
        transform.position = new Vector3(0, 5, 8);
        transform.rotation = UnityEngine.Random.rotation;
        rb.AddForce(transform.up * 500);
        rb.AddTorque(dirX, dirY, dirZ);

    }
}
