using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideCheck : MonoBehaviour
{
    public int timer;
    public int checkTime = 450;

    //Bools for numberdice
    public bool blueDice;
    public bool blue10;
    public bool blue20;

    //Bools for firstmarketdice
    public bool windmill;
    public bool fish;
    public bool flower;
    public bool boat;
    public bool wheel;
    public bool stones;

    //Bools for secondmarketdice
    public bool windmill2;
    public bool fish2;
    public bool flower2;
    public bool boat2;
    public bool wheel2;
    public bool stones2;

    public bool autoEN;

    [SerializeField] private ButtonPress ButtonPress;

    void Update()
    {
        autoEN = ButtonPress.automaticEnabled;

        //Resets all bools when the button is pressed
        if (ButtonPress.pressed)
        {
            blueDice = false;
            blue10 = false;
            blue20 = false;

            windmill = false;
            fish = false;
            flower = false;
            boat = false;
            wheel = false;
            stones = false;

            windmill2 = false;
            fish2 = false;
            flower2 = false;
            boat2 = false;
            wheel2 = false;
            stones2 = false;

            timer = 0;
        }

        timer++;
    }

    void OnTriggerStay(Collider col)
    {
        if (autoEN)
        {
            if (timer >= checkTime)
            {

                //Checks what object collides with the checkzone and acts according to the name
                switch (col.gameObject.name)
                {
                    //Numbered dices
                    case "Side1":
                        blueDice = true;
                        blue20 = true;
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
                        blue10 = true;
                        break;
                    
                    //First MarketDice
                    case "Windmill":
                        stones = true;
                        break;
                    case "Fish":
                        wheel = true;
                        break;
                    case "Flower":
                        boat = true;
                        break;
                    case "Boat":
                        flower = true;
                        break;
                    case "Wheel":
                        fish = true;
                        break;
                    case "Stones":
                        windmill = true;
                        break;
                    
                    //Second MarketDice
                    case "Windmill2":
                        stones2 = true;
                        break;
                    case "Fish2":
                        wheel2 = true;
                        break;
                    case "Flower2":
                        boat2 = true;
                        break;
                    case "Boat2":
                        flower2 = true;
                        break;
                    case "Wheel2":
                        fish2 = true;
                        break;
                    case "Stones2":
                        windmill2 = true;
                        break;
                }
            }
        }
    }
}