using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    #region Variables


    #region Public Vars
    public GameObject[] b;
    public GameObject[] a;
    public GameObject[] pawns;
    public int inplay;
    public int plase;
    public bool SecondDice;
    #endregion

    #region Serialized Vars
    #endregion

    #region Private Vars

    GameObject selected;
    #endregion


    #endregion

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            pawns[i].transform.position = new Vector3(a[3].transform.position.x, pawns[i].transform.position.y, a[3].transform.position.z);
        }
    }


    void LateUpdate()
    {

        for (int i = 0; i < 12; i++)
        {
            if (pawns[inplay].transform.position.x > a[i].transform.position.x-1 && pawns[inplay].transform.position.x < a[i].transform.position.x+1 && pawns[inplay].transform.position.z > a[i].transform.position.z - 1 && pawns[inplay].transform.position.z < a[i].transform.position.z + 1)
            {
                plase = i;
            }
        }

        if ((pawns[inplay].transform.position.x == b[inplay].transform.position.x && pawns[inplay].transform.position.z == b[inplay].transform.position.z) && inplay < 4)
        {
            inplay++;
        }

        if (inplay > 2)
        {
            SecondDice = true;
        }

        //Raycast Actions
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            int layerMask1 = LayerMask.GetMask("Water");
            int layerMask2 = LayerMask.GetMask("lokaties");

            if (selected == null)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask1))
                {
                    if (hit.collider.CompareTag("pawn"))
                    {
                        if (hit.collider.gameObject == pawns[inplay])
                        {
                            selected = hit.collider.gameObject;
                            selected.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y + 0.5f, selected.transform.position.z);
                            selected.GetComponent<Rigidbody>().useGravity = false;
                        }
                    }
                }
            }
            else
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask2))
                {
                    if (hit.collider.CompareTag("paddestoel"))
                    {
                        selected.transform.position = new Vector3(hit.collider.transform.position.x, 2f, hit.collider.transform.position.z);
                        selected.GetComponent<Rigidbody>().useGravity = true;
                        selected = null;
                    }
                    
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (selected != null)
            {
                selected.GetComponent<Rigidbody>().useGravity = true;
                selected = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pawns[inplay].transform.position = new Vector3(a[plase + 1].transform.position.x, 2f, a[plase + 1].transform.position.z);
            Debug.Log("up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pawns[inplay].transform.position = new Vector3(a[plase - 1].transform.position.x, 2f, a[plase - 1].transform.position.z);
            Debug.Log("down");
        }

    }
}
