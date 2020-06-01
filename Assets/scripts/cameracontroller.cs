using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameracontroller : MonoBehaviour
{
    #region Variables


    #region Public Vars
    public GameObject[] b;
    public GameObject[] a;
    public GameObject[] pawns;
    public GameObject[] knoppies;
    public int inplay;
    public int time;
    public int plase;
    public int startPos = 0;
    public int bankrunCount;
    public int toMove;
    public int playerCount;
    public int location;
    public bool SecondDice;
    public bool moving;

    public GameObject activator;
    public GameObject cam;
    public GameObject rotator;
    public GameObject popup;
    public GameObject bank;
    public GameObject numDice;
    public GameObject makDice1;
    public GameObject makDice2;
    public GameObject makDice1B;
    public GameObject makDice2B;
    public GameObject klaar;
    public GameObject regels;
    public GameObject exit;
    public GameObject tutorial;
    //public GameObject tutorialChoose;

    GameObject PopUpPanelColor;
    GameObject CameraTutorial;
    GameObject LichtTutorial;
    GameObject Canvas;
    GameObject turorial;
    GameObject tutorialChoose;

    public float display;

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
        PopUpPanelColor = GameObject.Find("PopUpPanelColor");
        CameraTutorial = GameObject.Find("Main CameraT");
        LichtTutorial = GameObject.Find("Directional Light");


        Popupscript popupscript = PopUpPanelColor.GetComponent<Popupscript>();

        startPos = (popupscript.playerCount - 6) * -1;
        bankrunCount = popupscript.bankrunCount;

        for (int i = 0; i < 6; i++)
        {
            pawns[i].transform.position = new Vector3(a[startPos].transform.position.x, pawns[i].transform.position.y, a[startPos].transform.position.z);
        }

        if (bankrunCount==1)
        {
            pawns[0].SetActive(true);
            pawns[1].SetActive(false);
            pawns[2].SetActive(false);
            pawns[3].SetActive(false);
            pawns[4].SetActive(false);
        }
        else if (bankrunCount == 2)
        {
            pawns[0].SetActive(true);
            pawns[1].SetActive(true);
            pawns[2].SetActive(false);
            pawns[3].SetActive(false);
            pawns[4].SetActive(false);

        }
        else if (bankrunCount == 3)
        {
            pawns[0].SetActive(true);
            pawns[1].SetActive(true);
            pawns[2].SetActive(true);
            pawns[3].SetActive(false);
            pawns[4].SetActive(false);
        }
        else if (bankrunCount == 4)
        {
            pawns[0].SetActive(true);
            pawns[1].SetActive(true);
            pawns[2].SetActive(true);
            pawns[3].SetActive(true);
            pawns[4].SetActive(false);

        }
        else if (bankrunCount == 5)
        {
            pawns[0].SetActive(true);
            pawns[1].SetActive(true);
            pawns[2].SetActive(true);
            pawns[3].SetActive(true);
            pawns[4].SetActive(true);
        }

    }

    void Awake()
    {
        PopUpPanelColor = GameObject.Find("PopUpPanelColor");
        CameraTutorial = GameObject.Find("Main CameraT");
        LichtTutorial = GameObject.Find("Directional Light");
        Canvas =  GameObject.Find("Canvas");
        turorial = GameObject.Find("Panel");
        tutorialChoose = GameObject.Find("TutorialChoose");

        //DontDestroyOnLoad(this.gameObject);
    }

    void LateUpdate()
    {

        blueDice = activator.GetComponent<NumberDiceCheckZoneScript>().blueDice;
        Blue10 = activator.GetComponent<NumberDiceCheckZoneScript>().blue10;
        Blue20 = activator.GetComponent<NumberDiceCheckZoneScript>().blue20;

        Windmill = activator.GetComponent<NumberDiceCheckZoneScript>().windmill;
        Fish = activator.GetComponent<NumberDiceCheckZoneScript>().fish;
        Flower = activator.GetComponent<NumberDiceCheckZoneScript>().flower;
        Boat = activator.GetComponent<NumberDiceCheckZoneScript>().boat;
        Wheel = activator.GetComponent<NumberDiceCheckZoneScript>().wheel;
        Stones = activator.GetComponent<NumberDiceCheckZoneScript>().stones;

        Windmill2 = activator.GetComponent<NumberDiceCheckZoneScript>().windmill2;
        Fish2 = activator.GetComponent<NumberDiceCheckZoneScript>().fish2;
        Flower2 = activator.GetComponent<NumberDiceCheckZoneScript>().flower2;
        Boat2 = activator.GetComponent<NumberDiceCheckZoneScript>().boat2;
        Wheel2 = activator.GetComponent<NumberDiceCheckZoneScript>().wheel2;
        Stones2 = activator.GetComponent<NumberDiceCheckZoneScript>().stones2;

        location = rotator.GetComponent<CamMove>().location;

        for (int i = 0; i < 12; i++)
        {
            if (pawns[inplay].transform.position.x > a[i].transform.position.x - 1 && pawns[inplay].transform.position.x < a[i].transform.position.x + 1 && pawns[inplay].transform.position.z > a[i].transform.position.z - 1 && pawns[inplay].transform.position.z < a[i].transform.position.z + 1)
            {
                plase = i;
            }
        }

        if ((pawns[inplay].transform.position.x == b[inplay].transform.position.x && pawns[inplay].transform.position.z == b[inplay].transform.position.z) && inplay < 5)
        {
            inplay++;
            Bankrun();
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
                    for (int i = 0; i < 7; i++)
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

                    if (hit.collider.gameObject == klaar)
                    {
                        bank.SetActive(false);
                    }
                    if (hit.collider.gameObject == regels)
                    {
                        
                        CameraTutorial.gameObject.SetActive(true);
                        LichtTutorial.gameObject.SetActive(true);
                        Canvas.gameObject.SetActive(true);
                        //turorial.gameObject.SetActive(true);
                        tutorialChoose.gameObject.SetActive(false);
                        PopUpPanelColor.gameObject.SetActive(false);

                        ButtonHandler other = (ButtonHandler)turorial.GetComponent(typeof(ButtonHandler));
                        other.TutorialBankrun();
                    }
                    if (hit.collider.gameObject == tutorial)
                    {
                        PopUpPanelColor.gameObject.SetActive(false);
                        CameraTutorial.gameObject.SetActive(true);
                        LichtTutorial.gameObject.SetActive(true);
                        Canvas.gameObject.SetActive(true);
                        turorial.gameObject.SetActive(false);
                        tutorialChoose.gameObject.SetActive(true);
                        // this.gameObject.SetActive(false);
                    }
                    if (hit.collider.gameObject == exit)
                    {
                        Application.Quit();
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
            if (display == 1)
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
            display++;
        }
        else
        {
            popup.SetActive(false);
            display = 0;
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

    void Bankrun()
    {
        toMove = 0;
        bank.SetActive(true);

        if (SecondDice)
        {
            makDice2B.SetActive(true);
        }
        else
        {
            makDice2B.SetActive(false);
        }

        if (location == 0)
        {
            makDice1B.transform.rotation = Quaternion.Euler(60, 270, 0);
            makDice2B.transform.rotation = Quaternion.Euler(60, 270, 0);
        }
        else if (location == 1)
        {
            makDice1B.transform.rotation = Quaternion.Euler(60, 0, 0);
            makDice2B.transform.rotation = Quaternion.Euler(60, 0, 0);
        }
        else if (location == -1)
        {
            makDice1B.transform.rotation = Quaternion.Euler(60, 180, 0);
            makDice2B.transform.rotation = Quaternion.Euler(60, 180, 0);
        }

        if (Windmill)
        {
            makDice1B.transform.Rotate(270.0f, 180.0f, 0.0f, Space.Self);
        }
        else if (Fish)
        {
            makDice1B.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        }
        else if (Flower)
        {
            makDice1B.transform.Rotate(180.0f, 180.0f, 0.0f, Space.Self);
        }
        else if (Boat)
        {
            makDice1B.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }
        else if (Wheel)
        {
            makDice1B.transform.Rotate(0.0f, 90.0f, 180.0f, Space.Self);
        }
        else if (Stones)
        {
            makDice1B.transform.Rotate(90.0f, 180.0f, 0.0f, Space.Self);
        }

        if (Windmill2)
        {
            makDice2B.transform.Rotate(270.0f, 180.0f, 0.0f, Space.Self);
        }
        else if (Fish2)
        {
            makDice2B.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        }
        else if (Flower2)
        {
            makDice2B.transform.Rotate(180.0f, 180.0f, 0.0f, Space.Self);
        }
        else if (Boat2)
        {
            makDice2B.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }
        else if (Wheel2)
        {
            makDice2B.transform.Rotate(0.0f, 90.0f, 180.0f, Space.Self);
        }
        else if (Stones2)
        {
            makDice2B.transform.Rotate(90.0f, 180.0f, 0.0f, Space.Self);
        }
    }
}
