using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    
    Vector3 pos;
    public bool pressed;
    public bool automaticEnabled;
    public GameObject mainCamera;
    public bool secondDice;
    bool throwable, always;

    //Variables for the moving of the button
    float posChangePerFrame = 0.008f;
    int maxDownFrames = 53;
    int maxUpFrames = 105;
    int moveTimer;

    //Creates dices to be linked for throwing
    [SerializeField] private DiceRoll secondMD;
    [SerializeField] private DiceRoll marketD;
    [SerializeField] private DiceRoll numberD;

    void Start()
    {
        always = true;
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

                    //Sets a boolean on so that the bluedice detection can start, used in NumberDiceCheckZone.cs
                    automaticEnabled = true;
                }
            }
        }

        ButtonDown();
        transform.position = pos;
    }

    void ThrowDice()
    {
        //Executes each dices script for throwing the die
        secondMD.Throw(throwable);
        marketD.Throw(always);
        numberD.Throw(always);
    }

    void EnableSecondMarketDice()
    {
        secondDice = mainCamera.GetComponent<cameracontroller>().secondDice;

        int secondDiceTimer = 0;

        if (secondDice)
        {
            if (secondDiceTimer == 0)
            {
                throwable = true;
                secondDiceTimer++;
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
                ThrowDice();
            }
            if (moveTimer < maxDownFrames)
            {
                pos.y -= posChangePerFrame;
            }
            else if (moveTimer < maxUpFrames)
            {
                pos.y += posChangePerFrame;
            }
            else
            {
                pressed = false;
                moveTimer = 0;
            }
        }
    }
}