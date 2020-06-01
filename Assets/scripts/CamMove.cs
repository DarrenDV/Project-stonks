using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamMove : MonoBehaviour
{
    public bool rechts;
    public bool links;
    public float speed;
    public int location;
    public int time;

    public GameObject leftButton;
    public GameObject rightButton;


    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "TutorialScene")
        {
            this.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            int layerMask3 = LayerMask.GetMask("UI");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask3))
            {
                if (hit.collider.CompareTag("GameController"))
                {
                    if (hit.collider.gameObject == rightButton)
                    {
                        rechts = true;
                        links = false;
                    }
                    if (hit.collider.gameObject == leftButton)
                    {
                        rechts = false;
                        links = true;
                    }
                }
            }
        }

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
        if (transform.rotation.y > -0.002 && transform.rotation.y < 0.002)
        {
            speed = 0;
            rechts = false;
            links = false;
            location = 0;
        }
    }
}