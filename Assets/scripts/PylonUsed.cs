using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PylonUsed : MonoBehaviour
{
    #region Public variables
    public int timer;
    public Toggle[] toggleArray = new Toggle[5];
    public GameObject[] pylons = new GameObject[5];
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

        pylons = GameObject.FindGameObjectsWithTag("Pylon");
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
            foreach (GameObject p in pylons)
            {
                foreach (Toggle t in toggleArray)
                {
                    if (t.name == p.name)
                    {
                        GameObject.FindWithTag(t.name).SetActive(t.isOn);
                        p.SetActive(t.isOn);
                    }
                    
                }
            }
        }
    }
    #endregion
}