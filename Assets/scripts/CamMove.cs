using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public bool rechts;
    public bool links;
    public float speed;
    public int location;
    public int time;

    public GameObject L;
    public GameObject R;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            int layerMask1 = LayerMask.GetMask("Water");
            int layerMask2 = LayerMask.GetMask("lokaties");
            int layerMask3 = LayerMask.GetMask("UI");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask3))
            {
                if (hit.collider.CompareTag("GameController"))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (hit.collider.gameObject == R)
                        {
                            rechts = true;
                            links = false;
                        }
                        if (hit.collider.gameObject == L)
                        {
                            rechts = false;
                            links = true;
                        }
                    }
                }
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rechts = true;
            links = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rechts = false;
            links = true;
        }
        */
        if (rechts && location != -1)
        {
            speed = -100;
            time++;
            location = 0;
        }
        if (links && location != 1)
        {
            speed = 100;
            time++;
            location = 0;
        }
        transform.Rotate(0, speed * Time.deltaTime, 0);
        if (transform.rotation.y > 0.705)
        {
            speed = 0;
            rechts = false;
            links = false;
            location = 1;
        }
        if (transform.rotation.y < -0.705)
        {
            speed = 0;
            rechts = false;
            links = false;
            location = -1;
        }
        if (transform.rotation.y > -0.0045 && transform.rotation.y < 0.0045)
        {
            speed = 0;
            rechts = false;
            links = false;
            location = 0;
        }
        Debug.Log(transform.rotation.y);
    }
}
