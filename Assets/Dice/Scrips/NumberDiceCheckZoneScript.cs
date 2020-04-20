using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDiceCheckZoneScript : MonoBehaviour
{

    Vector3 diceVelocity;
    public bool blueDice = false;

    void FixedUpdate()
    {
        diceVelocity = NumberDiceRoll.diceVelocity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blueDice = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Side1":
                    blueDice = true;
                    break;
                case "Side2":
                    break;
                case "Side3":
                    break;
                case "Side4":
                    break;
                case "Side5":
                    break;
                case "Side6":
                    blueDice = true;
                    break;
            }
        }
    }
}
