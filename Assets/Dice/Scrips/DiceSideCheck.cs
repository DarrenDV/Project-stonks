using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideCheck : MonoBehaviour
{
    public int timer;
    public int checkTime = 450;

    //Bool for numberdice
    public bool blueDice;

    public string diceNumSide;
    public string diceMarketdice;
    public string diceMarketdice2;

    public bool autoEN;

    [SerializeField] private ButtonPress ButtonPress;

    void FixedUpdate()
    {
        autoEN = ButtonPress.automaticEnabled;

        //Resets all bools when the button is pressed
        if (ButtonPress.pressed)
        {
            blueDice = false;

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
                        diceNumSide = "20";
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
                        diceNumSide = "10";
                        break;
                    
                    //First MarketDice
                    case "Windmill":
                        diceMarketdice = "stones"; 
                        break;
                    case "Fish":
                        diceMarketdice = "wheel";
                        break;
                    case "Flower":
                        diceMarketdice = "boat";
                        break;
                    case "Boat":
                        diceMarketdice = "flower";
                        break;
                    case "Wheel":
                        diceMarketdice = "fish";
                        break;
                    case "Stones":
                        diceMarketdice = "windmill";
                        break;
                    
                    //Second MarketDice
                    case "Windmill2":
                        diceMarketdice2 = "stones";
                        break;
                    case "Fish2":
                        diceMarketdice2 = "wheel";
                        break;
                    case "Flower2":
                        diceMarketdice2 = "boat";
                        break;
                    case "Boat2":
                        diceMarketdice2 = "flower";
                        break;
                    case "Wheel2":
                        diceMarketdice2 = "fish";
                        break;
                    case "Stones2":
                        diceMarketdice2 = "windmill";
                        break;
                }
            }
        }
    }
}