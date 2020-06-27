using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    #region Variables


    #region Public Vars

    //Gameobjectlist van fiches en plaatsen en popupknoppen
    public GameObject[] bankRunLocaties;
    public GameObject[] locaties;
    public GameObject[] pawns;
    public GameObject[] knoppies;
    public GameObject[] bankRunBlauwDobbels;
    public GameObject[] bankRunDobbels;
    public int inplay;
    public int time;
    public int place;
    public int startPos = 0;
    public int bankrunCount;
    public int toMove;
    public int playerCount;
    public int location;

    public GameObject activator;
    public GameObject cam;
    public GameObject rotator;
    public GameObject popup;
    public GameObject bank;
    public GameObject numberDice;
    public GameObject marktDice1;
    public GameObject marktDice2;
    public GameObject marktDice1B;
    public GameObject marktDice2B;
    public GameObject klaar;
    public GameObject regels;
    public GameObject exit;
    public GameObject tutorialKnop;

    //GameObjecten uit tutorialscene
    GameObject popUpPanelColor;
    GameObject cameraTutorial;
    GameObject lichtTutorial;
    GameObject canvas;
    GameObject tutorial;
    GameObject tutorialChoose;

    public float display;

    //Booleans van de dobbelsteen kanten
    public bool secondDice;
    public bool blueDice;

    public string diceNumSide;
    public string diceMarketdice;
    public string diceMarketdice2;
    #endregion

    #region Serialized Vars
    #endregion

    #region Private Vars

    GameObject selected;
    #endregion


    #endregion

    void Start()
    {
        popUpPanelColor = GameObject.Find("PopUpPanelColor");
        cameraTutorial = GameObject.Find("Main CameraT");
        lichtTutorial = GameObject.Find("Directional Light");


        Popupscript popupscript = popUpPanelColor.GetComponent<Popupscript>();

        //Starpositie van de bankrunfiches en aantal bepaald
        startPos = (popupscript.playerCount - 6) * -1;
        bankrunCount = popupscript.bankrunCount;

        for (int i = 0; i < 6; i++)
        {
            pawns[i].transform.position = new Vector3(locaties[startPos].transform.position.x, pawns[i].transform.position.y, locaties[startPos].transform.position.z);
        }

        if (bankrunCount == 1)
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
        popUpPanelColor = GameObject.Find("PopUpPanelColor");
        cameraTutorial = GameObject.Find("Main CameraT");
        lichtTutorial = GameObject.Find("Directional Light");
        canvas = GameObject.Find("Canvas");
        tutorial = GameObject.Find("Panel");
        tutorialChoose = GameObject.Find("TutorialChoose");
    }

    void LateUpdate()
    {
        //Haalt alle booleans uit checkscript
        blueDice = activator.GetComponent<DiceSideCheck>().blueDice;

        diceNumSide = activator.GetComponent<DiceSideCheck>().diceNumSide;
        diceMarketdice = activator.GetComponent<DiceSideCheck>().diceMarketdice;
        diceMarketdice2 = activator.GetComponent<DiceSideCheck>().diceMarketdice2;

        location = rotator.GetComponent<CamMove>().location;

        //Checked de locatie van het fiche
        for (int i = 0; i < 12; i++)
        {
            if (pawns[inplay].transform.position.x > locaties[i].transform.position.x - 1 &&
                pawns[inplay].transform.position.x < locaties[i].transform.position.x + 1 &&
                pawns[inplay].transform.position.z > locaties[i].transform.position.z - 1 &&
                pawns[inplay].transform.position.z < locaties[i].transform.position.z + 1)
            {
                place = i;
            }
        }

        //Activeert de bankrunpopup al komt er een fiche op een bankrunplaats
        if ((pawns[inplay].transform.position.x == bankRunLocaties[inplay].transform.position.x &&
            pawns[inplay].transform.position.z == bankRunLocaties[inplay].transform.position.z) && inplay < 5)
        {
            inplay++;
            Bankrun();
        }

        //Zet de 2e dobbelsteen aan
        if (inplay > 2)
        {
            secondDice = true;
        }

        //Checked waar de muis op klikt
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

                        //Verplaatst de geselecteerde fiche omhoog, aangeven dat je hem hebt geselecteerd
                        if (hit.collider.gameObject == pawns[inplay])
                        {
                            selected = hit.collider.gameObject;
                            selected.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y + 0.5f, selected.transform.position.z);
                            selected.GetComponent<Rigidbody>().useGravity = false;
                        }
                    }
                }
            }

            //Verplaatst het fiche naar een nieuwe locatie
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

            //Checked waar je op klikt in de bluedicepopup
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask3))
            {
                if (hit.collider.CompareTag("GameController"))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (hit.collider.gameObject == knoppies[i])
                        {
                            toMove = i;
                            popup.SetActive(false);
                        }
                    }

                    //Checked waar je op klikt
                    if (hit.collider.gameObject == klaar)
                    {
                        bank.SetActive(false);
                    }
                    if (hit.collider.gameObject == regels)
                    {
                        cameraTutorial.gameObject.SetActive(true);
                        lichtTutorial.gameObject.SetActive(true);
                        canvas.gameObject.SetActive(true);
                        tutorialChoose.gameObject.SetActive(false);
                        popUpPanelColor.gameObject.SetActive(false);

                        ButtonHandler other = (ButtonHandler)tutorial.GetComponent(typeof(ButtonHandler));
                        other.TutorialBankrun();
                    }
                    if (hit.collider.gameObject == tutorialKnop)
                    {
                        popUpPanelColor.gameObject.SetActive(false);
                        cameraTutorial.gameObject.SetActive(true);
                        lichtTutorial.gameObject.SetActive(true);
                        canvas.gameObject.SetActive(true);
                        tutorial.gameObject.SetActive(false);
                        tutorialChoose.gameObject.SetActive(true);
                    }
                    if (hit.collider.gameObject == exit)
                    {
                        Application.Quit();
                    }
                }
            }
        }

        //Deselecteerd op misklik
        if (Input.GetMouseButtonDown(1))
        {
            if (selected != null)
            {
                selected.GetComponent<Rigidbody>().useGravity = true;
                selected = null;
            }
        }

        //Verplaatst het fiche op mooie wijze naar de nieuwe plaats
        if (toMove > 0)
        {
            if (time % 30 == 0)
            {
                pawns[inplay].transform.position = new Vector3(locaties[place + 1].transform.position.x, 2f, locaties[place + 1].transform.position.z);
                toMove--;
            }
            time++;
        }

        //Zet de dobbelsteen op de goede kant in de bluedicepopup
        if (blueDice)
        {
            if (display == 1)
            {
                popup.SetActive(true);

                foreach (GameObject dobbel in bankRunBlauwDobbels)
                {
                    dobbel.GetComponent<DobbelDraai>().location = location;
                    dobbel.GetComponent<DobbelDraai>().set = true;
                }

                numberDice.GetComponent<DobbelDraai>().side = diceNumSide;
                marktDice1.GetComponent<DobbelDraai>().side = diceMarketdice;
                marktDice2.GetComponent<DobbelDraai>().side = diceMarketdice2;
            }
            display++;
        }
        else
        {
            popup.SetActive(false);
            display = 0;
        }

        if (secondDice)
        {
            marktDice2.SetActive(true);
        }
        else
        {
            marktDice2.SetActive(false);
        }
    }

    //Zet de dobbelstenen op de juiste kant in de bankrunpopup
    void Bankrun()
    {
        toMove = 0;
        bank.SetActive(true);

        if (secondDice)
        {
            marktDice2B.SetActive(true);
        }
        else
        {
            marktDice2B.SetActive(false);
        }

        foreach (GameObject dobbel in bankRunDobbels)
        {
            dobbel.GetComponent<DobbelDraai>().location = location;
            dobbel.GetComponent<DobbelDraai>().set = true;
        }

        marktDice1B.GetComponent<DobbelDraai>().side = diceMarketdice;
        marktDice2B.GetComponent<DobbelDraai>().side = diceMarketdice2;
    }
}