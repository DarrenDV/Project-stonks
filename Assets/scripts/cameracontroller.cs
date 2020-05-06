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
    public int time;
    public int kijk;
    public int plase;
    public int startPos = 0;
    public int toMove;
    public int playerCount;
    public int location;
    public bool SecondDice;
    public bool moving;

    public GameObject activator;
    public GameObject cam;
    public GameObject rotator;
    public GameObject popup;
    public GameObject[] knoppies;
    public GameObject numDice;
    public GameObject makDice1;
    public GameObject makDice2;

    public bool blueDice;
    public bool Blue10;
    public bool Blue20;

    public bool Windmill;
    public bool Fish;
    public bool Flower;
    public bool Boat;
    public bool Wheel;
    public bool Stones;

    public bool Windmill2;
    public bool Fish2;
    public bool Flower2;
    public bool Boat2;
    public bool Wheel2;
    public bool Stones2;
    #endregion

    #region Serialized Vars
    #endregion

    #region Private Vars

    GameObject selected;
    #endregion


    #endregion

    void Start()
    {
        GameObject PopUpPanelColor = GameObject.Find("PopUpPanelColor");
        Popupscript popupscript = PopUpPanelColor.GetComponent<Popupscript>();

        startPos = (popupscript.playerCount - 6) * -1;

        for (int i = 0; i < 5; i++)
        {
            pawns[i].transform.position = new Vector3(a[startPos].transform.position.x, pawns[i].transform.position.y, a[startPos].transform.position.z);
        }

    }


    void LateUpdate()
    {
        blueDice = activator.GetComponent<NumberDiceCheckZoneScript>().blueDice;
        Blue10 = activator.GetComponent<NumberDiceCheckZoneScript>().Blue10;
        Blue20 = activator.GetComponent<NumberDiceCheckZoneScript>().Blue20;

        Windmill = activator.GetComponent<NumberDiceCheckZoneScript>().Windmill;
        Fish = activator.GetComponent<NumberDiceCheckZoneScript>().Fish;
        Flower = activator.GetComponent<NumberDiceCheckZoneScript>().Flower;
        Boat = activator.GetComponent<NumberDiceCheckZoneScript>().Boat;
        Wheel = activator.GetComponent<NumberDiceCheckZoneScript>().Wheel;
        Stones = activator.GetComponent<NumberDiceCheckZoneScript>().Stones;

        Windmill2 = activator.GetComponent<NumberDiceCheckZoneScript>().Windmill2;
        Fish2 = activator.GetComponent<NumberDiceCheckZoneScript>().Fish2;
        Flower2 = activator.GetComponent<NumberDiceCheckZoneScript>().Flower2;
        Boat2 = activator.GetComponent<NumberDiceCheckZoneScript>().Boat2;
        Wheel2 = activator.GetComponent<NumberDiceCheckZoneScript>().Wheel2;
        Stones2 = activator.GetComponent<NumberDiceCheckZoneScript>().Stones2;

        location = rotator.GetComponent<CamMove>().location;

        for (int i = 0; i < 12; i++)
        {
            if (pawns[inplay].transform.position.x > a[i].transform.position.x - 1 && pawns[inplay].transform.position.x < a[i].transform.position.x + 1 && pawns[inplay].transform.position.z > a[i].transform.position.z - 1 && pawns[inplay].transform.position.z < a[i].transform.position.z + 1)
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
            int layerMask3 = LayerMask.GetMask("UI");

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

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask3))
            {
                if (hit.collider.CompareTag("GameController"))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (hit.collider.gameObject == knoppies[i])
                        {
                            toMove = i;
                            if (location == 0)
                            {
                                numDice.transform.rotation = Quaternion.Euler(60, 270, 0);
                                makDice1.transform.rotation = Quaternion.Euler(60, 270, 0);
                                makDice2.transform.rotation = Quaternion.Euler(60, 270, 0);
                            }
                            else if (location == 1)
                            {
                                numDice.transform.rotation = Quaternion.Euler(60, 0, 0);
                                makDice1.transform.rotation = Quaternion.Euler(60, 0, 0);
                                makDice2.transform.rotation = Quaternion.Euler(60, 0, 0);
                            }
                            else if (location == -1)
                            {
                                numDice.transform.rotation = Quaternion.Euler(60, 180, 0);
                                makDice1.transform.rotation = Quaternion.Euler(60, 180, 0);
                                makDice2.transform.rotation = Quaternion.Euler(60, 180, 0);
                            }

                            popup.SetActive(false);
                        }
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
        /*
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
        */
        if (toMove > 0)
        {
            if (time % 60 == 0)
            {
                pawns[inplay].transform.position = new Vector3(a[plase + 1].transform.position.x, 2f, a[plase + 1].transform.position.z);
                toMove--;
            }
            time++;
        }

        if (blueDice)
        {
            if (kijk == 120)
            {
                popup.SetActive(true);
                if (Blue10)
                {
                    numDice.transform.Rotate(270.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (Blue20)
                {
                    numDice.transform.Rotate(90.0f, 180.0f, 0.0f, Space.Self);
                }

                if (Windmill)
                {
                    makDice1.transform.Rotate(270.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (Fish)
                {
                    makDice1.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                }
                else if (Flower)
                {
                    makDice1.transform.Rotate(180.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (Boat)
                {
                    makDice1.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (Wheel)
                {
                    makDice1.transform.Rotate(0.0f, 90.0f, 180.0f, Space.Self);
                }
                else if (Stones)
                {
                    makDice1.transform.Rotate(90.0f, 180.0f, 0.0f, Space.Self);
                }

                if (Windmill2)
                {
                    makDice2.transform.Rotate(270.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (Fish2)
                {
                    makDice2.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                }
                else if (Flower2)
                {
                    makDice2.transform.Rotate(180.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (Boat2)
                {
                    makDice2.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (Wheel2)
                {
                    makDice2.transform.Rotate(0.0f, 90.0f, 180.0f, Space.Self);
                }
                else if (Stones2)
                {
                    makDice2.transform.Rotate(90.0f, 180.0f, 0.0f, Space.Self);
                }
            }
            kijk++;
        }
        else
        {
            popup.SetActive(false);
            kijk = 0;
        }

        if (SecondDice)
        {
            makDice2.SetActive(true);
        }
        else
        {
            makDice2.SetActive(false);
        }
    }
}
