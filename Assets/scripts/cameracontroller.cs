using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    #region Variables


    #region Public Vars
    public GameObject[] b;
    public GameObject[] pawns;
    public int inplay;
    #endregion

    #region Serialized Vars
    #endregion

    #region Private Vars

    GameObject selected;
    #endregion


    #endregion

    void Start()
    {
    }


    void LateUpdate()
    {
        if ((pawns[inplay].transform.position.x == b[inplay].transform.position.x && pawns[inplay].transform.position.z == b[inplay].transform.position.z) && inplay < 5)
        {
            inplay++;
        }



        //Raycast Actions
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (selected == null)
                {
                    if (hit.collider.CompareTag("pawn"))
                    {
                        if (hit.collider.gameObject == pawns[inplay])
                        {
                            if (selected == null)
                            {
                                selected = hit.collider.gameObject;
                                selected.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y + 0.5f, selected.transform.position.z);
                                selected.GetComponent<Rigidbody>().useGravity = false;
                            }
                        }
                    }
                    else
                    {
                        selected.GetComponent<Rigidbody>().useGravity = true;
                        selected = null;
                    }
                }
                if (hit.collider.CompareTag("paddestoel"))
                {
                    if (selected != null)
                    {
                        selected.transform.position = new Vector3(hit.collider.transform.position.x, 1f, hit.collider.transform.position.z);
                        selected.GetComponent<Rigidbody>().useGravity = true;
                        selected = null;
                        
                    }
                }
                if (hit.collider.CompareTag("pawn") && pawns[inplay] != selected)
                {
                    if (selected != null)
                    {
                        selected.transform.position = new Vector3(hit.collider.transform.position.x, selected.transform.position.y, hit.collider.transform.position.z);
                        selected.GetComponent<Rigidbody>().useGravity = true;
                        selected = null;
                        Debug.Log(hit.collider);
                    }
                }
                Debug.Log(selected);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            selected.GetComponent<Rigidbody>().useGravity = true; 
            selected = null;
        }
    }
}
