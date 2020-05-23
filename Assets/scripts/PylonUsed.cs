using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonUsed : MonoBehaviour
{
    public bool oranje;
    public bool blauw;
    public bool paars;
    public bool roze;
    public bool grijs;
    public bool groen;
    public GameObject orange;
    public GameObject blue;
    public GameObject purple;
    public GameObject pink;
    public GameObject grey;
    public GameObject green;
    public int timer;

    void Start()
    {
        GameObject PopUpPanelColor = GameObject.Find("PopUpPanelColor");
        GameObject  CameraTutorial = GameObject.Find("Main CameraT");
        GameObject LichtTutorial = GameObject.Find("Directional Light");

        Popupscript popupscript = PopUpPanelColor.GetComponent<Popupscript>();
        PopUpPanelColor.gameObject.SetActive(false);
        CameraTutorial.gameObject.SetActive(false);
        LichtTutorial.gameObject.SetActive(false);

        oranje = popupscript.oranje;
        blauw = popupscript.blauw;
        paars = popupscript.paars;
        roze = popupscript.roze;
        grijs = popupscript.grijs;
        groen = popupscript.groen;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer < 8)
        {
            if (oranje == true)
            {
                orange.SetActive(true);
                GameObject.FindWithTag("pylonRed").SetActive(true);
            }
            else
            {
                orange.SetActive(false);
                GameObject.FindWithTag("pylonRed").SetActive(false);
            }


            if (blauw == true)
            {
                blue.SetActive(true);
                GameObject.FindWithTag("pylonBlue").SetActive(true);

            }
            else
            {
                blue.SetActive(false);
                GameObject.FindWithTag("pylonBlue").SetActive(false);
            }


            if (paars == true)
            {
                purple.SetActive(true);
                GameObject.FindWithTag("pylonPurple").SetActive(true);

            }
            else
            {
                purple.SetActive(false);
                GameObject.FindWithTag("pylonPurple").SetActive(false);
            }


            if (roze == true)
            {
                pink.SetActive(true);
                GameObject.FindWithTag("pylonOrange").SetActive(true);

            }
            else
            {
                pink.SetActive(false);
                GameObject.FindWithTag("pylonOrange").SetActive(false);
            }


            if (grijs == true)
            {
                grey.SetActive(true);
                GameObject.FindWithTag("pylonGrey").SetActive(true);

            }
            else
            {
                grey.SetActive(false);
                GameObject.FindWithTag("pylonGrey").SetActive(false);
            }


            if (groen == true)
            {
                green.SetActive(true);
                GameObject.FindWithTag("pylonGreen").SetActive(true);

            }
            else
            {
                green.SetActive(false);
                GameObject.FindWithTag("pylonGreen").SetActive(false);
            }
        }
    }
}
