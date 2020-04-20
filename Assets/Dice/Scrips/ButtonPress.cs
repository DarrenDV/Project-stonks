using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    int MoveTimer;
    float posY = 0.14f;
    Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveTimer = 0;
            if(MoveTimer < 14)
            {
                posY -= 0.01f;
                MoveTimer++;
            }
            if(MoveTimer >= 14 && MoveTimer < 29)
            {
                posY += 0.01f;
                MoveTimer++;
            }
            pos.y = posY;
            transform.position = pos;

         

        }

        
    }
}
