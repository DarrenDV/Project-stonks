using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMarketDice : MonoBehaviour
{
    public bool SecondDice;
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public int moveTimer;
    public GameObject camera;
    bool Throwable;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    public void Update()
    {
        SecondDice = camera.GetComponent<cameracontroller>().SecondDice;

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

                float dirX = Random.Range(0, 500);
                float dirY = Random.Range(0, 500);
                float dirZ = Random.Range(0, 500);
                transform.position = new Vector3(2, 5, 10);
                transform.rotation = Quaternion.identity;
                rb.AddForce(transform.up * 500);
                rb.AddTorque(dirX, dirY, dirZ);
            }
        }

}
