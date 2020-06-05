using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public bool secondDice;
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public int moveTimer;
    //public GameObject Camera;

    public void Start()
    {
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

    public void Throw(bool throwable)
    {
        if (throwable)
        {
            rb = GetComponent<Rigidbody>();

            diceVelocity = rb.velocity;

            //Makes random dirs for the torque
            float dirX = UnityEngine.Random.Range(0, 1000);
            float dirY = UnityEngine.Random.Range(0, 1000);
            float dirZ = UnityEngine.Random.Range(0, 1000);

            //Standard position for the die
            transform.position = new Vector3(2, 5, 10);

            transform.rotation = UnityEngine.Random.rotation;
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
