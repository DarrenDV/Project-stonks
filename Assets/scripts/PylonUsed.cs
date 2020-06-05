using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PylonUsed : MonoBehaviour
{
    #region Public variables
    public GameObject orange;
    public GameObject blue;
    public GameObject purple;
    public GameObject pink;
    public GameObject grey;
    public GameObject green;
    public int timer;
    public Toggle[] toggleArray = new Toggle[5];
    #endregion

    void Start()
    {
        GameObject popUpPanelColor = GameObject.Find("PopUpPanelColor");
        GameObject cameraTutorial = GameObject.Find("Main CameraT");
        GameObject lichtTutorial = GameObject.Find("Directional Light");
        GameObject canvas = GameObject.Find("Canvas");

        Popupscript popupscript = popUpPanelColor.GetComponent<Popupscript>();
        toggleArray = popupscript.toggleArray;
        popUpPanelColor.gameObject.SetActive(false);
        cameraTutorial.gameObject.SetActive(false);
        lichtTutorial.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
    }

    #region Update
    /// <summary>
    /// Hier word gechecked welke pylon (kleur) word geselecteerd in het startscherm
    /// en vervolgens worden said pylons geketend op het bord
    /// (By default staan alle pylonnen uit)
    /// </summary>
    void Update()
    {
        timer++;
        if (timer < 8)
        {

            foreach (Toggle t in toggleArray)
            {
                if (t.name == "Oranje") 
                { 
                    orange.SetActive(t.isOn);
                    GameObject.FindWithTag("pylonRed").SetActive(t.isOn);
                }

                if (t.name == "Blauw")
                {
                    blue.SetActive(t.isOn);
                    GameObject.FindWithTag("pylonBlue").SetActive(t.isOn);

                }

                if (t.name == "Paars")
                {
                    purple.SetActive(t.isOn);
                    GameObject.FindWithTag("pylonPurple").SetActive(t.isOn);

                }

                if (t.name == "Roze")
                {
                    pink.SetActive(t.isOn);
                    GameObject.FindWithTag("pylonOrange").SetActive(t.isOn);

                }

                if (t.name == "Grijs")
                {
                    grey.SetActive(t.isOn);
                    GameObject.FindWithTag("pylonGrey").SetActive(t.isOn);

                }

                if (t.name == "Groen")
                {
                    green.SetActive(t.isOn);
                    GameObject.FindWithTag("pylonGreen").SetActive(t.isOn);

                }
            }
        }
    }
    #endregion
}