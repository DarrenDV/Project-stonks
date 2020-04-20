using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    int MoveTimer;
    Vector3 pos;
    bool Pressed;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {  
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.CompareTag("DiceButton"))
                {
                    Pressed = true;
                }
            }
        }

        ButtonDown();
        transform.position = pos;
    }

    void Throw()
    {

    }

    void ButtonDown()
    {
        if (Pressed)
        {
            MoveTimer++;
            if(MoveTimer == 1)
            {
                Throw();
            }
            if (MoveTimer < 53)
            {
                pos.y -= 0.005f;
            }
            else if (MoveTimer < 105)
            {
                pos.y += 0.005f;
            }
            else
            {
                Pressed = false;
                MoveTimer = 0;
            }
        }
    }
}
