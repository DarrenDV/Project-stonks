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
            int layerMask1 = LayerMask.GetMask("Water");

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask1))
            {

                if (hit.collider.CompareTag("Pylon"))
                {

                    if (selected1 == null)
                    {

                        selected1 = hit.collider.gameObject;
                        selected1.transform.position = new Vector3(selected1.transform.position.x, selected1.transform.position.y + 0.1f, selected1.transform.position.z);
                        selected1.GetComponent<Rigidbody>().useGravity = false;

                    }
                    else
                    {
                        selected1.GetComponent<Rigidbody>().useGravity = true;
                        selected1 = null;
                    }
                }
                if (hit.collider.CompareTag("playerLevel"))
                {
                    if (selected1 != null)
                    {
                        selected1.transform.position = new Vector3(hit.collider.transform.position.x, selected1.transform.position.y , selected1.transform.position.z);
                        selected1.GetComponent<Rigidbody>().useGravity = true;
                        selected1 = null;
                    }
                }

            }

        }

        if (Input.GetMouseButtonDown(1)) selected1 = null;

    }
}
