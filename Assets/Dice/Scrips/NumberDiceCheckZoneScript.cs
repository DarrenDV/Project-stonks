using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDiceCheckZoneScript : MonoBehaviour
{
    public int Timer;

    public bool blueDice;
    public bool Blue10;
    public bool Blue20;

    public bool Windmill;
    public bool Fish;
    public bool Flower;
    public bool Boat;
    public bool Wheel;
    public bool Stones;

    public bool Windmill2;
    public bool Fish2;
    public bool Flower2;
    public bool Boat2;
    public bool Wheel2;
    public bool Stones2;

    public bool AutoEN;

    [SerializeField] private ButtonPress ButtonPress;

    void Update()
    {
        AutoEN = ButtonPress.AutomaticEnabled;

        if (ButtonPress.Pressed)
        {
            blueDice = false;
            Blue10 = false;
            Blue20 = false;

            Windmill = false;
            Fish = false;
            Flower = false;
            Boat = false;
            Wheel = false;
            Stones = false;

            Windmill2 = false;
            Fish2 = false;
            Flower2 = false;
            Boat2 = false;
            Wheel2 = false;
            Stones2 = false;

            Timer = 0;
        }

        Timer++;
    }

    void OnTriggerStay(Collider col)
    {
        if (AutoEN)
        {
            if (Timer >= 600)
            {
                switch (col.gameObject.name)
                {
                    case "Side1":
                        blueDice = true;
                        Blue20 = true;
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
                        Blue10 = true;
                        break;

                    case "Windmill":
                        Stones = true;
                        break;
                    case "Fish":
                        Wheel = true;
                        break;
                    case "Flower":
                        Boat = true;
                        break;
                    case "Boat":
                        Flower = true;
                        break;
                    case "Wheel":
                        Fish = true;
                        break;
                    case "Stones":
                        Windmill = true;
                        break;

                    case "Windmill2":
                        Stones2 = true;
                        break;
                    case "Fish2":
                        Wheel2 = true;
                        break;
                    case "Flower2":
                        Boat2 = true;
                        break;
                    case "Boat2":
                        Flower2 = true;
                        break;
                    case "Wheel2":
                        Fish2 = true;
                        break;
                    case "Stones2":
                        Windmill2 = true;
                        break;
                }
            }
        }
    }
}
