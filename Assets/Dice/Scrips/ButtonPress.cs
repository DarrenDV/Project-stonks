using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    int moveTimer;
    Vector3 pos;
    public bool pressed;
    public bool automaticEnabled;

    public GameObject camera;
    public bool secondDice;
    bool throwable;

    //Creates dices to be linked for throwing
    //[SerializeField] private MarketDiceRoll marketDR;
    //[SerializeField] private NumberDiceRoll numberDR;
    //[SerializeField] private SecondMarketDice secondMD;
    [SerializeField] private DiceRoll secondMD;
    [SerializeField] private DiceRoll marketD;
    [SerializeField] private DiceRoll numberD;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {

        EnableSecondMarketDice();

        //Checks if the mouse is pressed on the button
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            int layerMask1 = LayerMask.GetMask("Water");

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask1))
            {
                if (hit.collider.CompareTag("DiceButton"))
                {
                    pressed = true;

                    //Sets a boolean on so that the bluedice detection can start
                    automaticEnabled = true;
                }
            }
        }

        ButtonDown();
        transform.position = pos;
    }

    void Throw()
    {
        //Executes each dices script for throwing the die
        // marketDR.Throw();
        // numberDR.Throw();
        marketD.Throw();
        numberD.Throw();

        if(throwable)
        {
        secondMD.Throw();
        }
    }

    void EnableSecondMarketDice()
    {
        secondDice = camera.GetComponent<cameracontroller>().secondDice;

        int moveTimer = 0;

        if (secondDice)
        {
            if (moveTimer == 0)
            {
                throwable = true;
                moveTimer++;
            }
        }
    }

    void ButtonDown()
    {
        //Moves the button down and up to give a "pressed" effect
        if (pressed)
        {
            moveTimer++;
            if(moveTimer == 1)
            {
                Throw();
            }
            if (moveTimer < 53)
            {
                pos.y -= 0.008f;
            }
            else if (moveTimer < 105)
            {
                pos.y += 0.008f;
            }
            else
            {
                pressed = false;
                moveTimer = 0;
            }
        }
    }
}