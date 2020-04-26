using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDiceCheckZoneScript : MonoBehaviour
{

    Vector3 diceVelocity;
    public bool blueDice;
    public bool AutoEN;
    [SerializeField] private ButtonPress ButtonPress;

    void FixedUpdate()
    {
        diceVelocity = NumberDiceRoll.diceVelocity;
    }

    void Update()
    {
        AutoEN = ButtonPress.AutomaticEnabled;
        if (ButtonPress.Pressed)
        {
            blueDice = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (AutoEN)
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
}
