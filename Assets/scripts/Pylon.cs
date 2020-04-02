using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon : MonoBehaviour
{

    GameObject selected1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {

                if (hit.collider.CompareTag("Pylon"))
                {

                    if (selected1 == null)
                    {

                        selected1 = hit.collider.gameObject;

                    }
                    else selected1 = null;
                }
                if (hit.collider.CompareTag("playerLevel"))
                {
                    if (selected1 != null)
                    {
                        selected1.transform.position = new Vector3(hit.collider.transform.position.x, 0.1f, selected1.transform.position.z);
                    }
                }

            }

        }

        if (Input.GetMouseButtonDown(1)) selected1 = null;

    }
}
