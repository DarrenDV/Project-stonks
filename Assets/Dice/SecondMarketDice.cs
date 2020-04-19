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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SecondDice = camera.GetComponent<cameracontroller>().SecondDice;

        if (SecondDice)
        {
            if(moveTimer == 0)
            {
                transform.position = new Vector3(0, 5, 14);
                moveTimer++;
            }

            diceVelocity = rb.velocity;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                float dirX = Random.Range(0, 500);
                float dirY = Random.Range(0, 500);
                float dirZ = Random.Range(0, 500);
                transform.position = new Vector3(0, 5, 14);
                transform.rotation = Quaternion.identity;
                rb.AddForce(transform.up * 500);
                rb.AddTorque(dirX, dirY, dirZ);
            }
        }
    }
}
