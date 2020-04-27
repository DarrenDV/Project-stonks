using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonUsed : MonoBehaviour
{
    public bool rood;
    public bool blauw;
    public bool paars;
    public bool geel;
    public bool zwart;
    public bool groen;
    public GameObject red;
    public GameObject blue;
    public GameObject purple;
    public GameObject orange;
    public GameObject grey;
    public GameObject green;
    public int timer;

    void Start()
    {
        GameObject PopUpPanelColor = GameObject.Find("PopUpPanelColor");
        Popupscript popupscript = PopUpPanelColor.GetComponent<Popupscript>();

        rood = popupscript.rood;
        blauw = popupscript.blauw;
        paars = popupscript.paars;
        geel = popupscript.geel;
        zwart = popupscript.zwart;
        groen = popupscript.groen;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer < 8)
        {
            if (rood == true)
            {
                red.SetActive(true);
                GameObject.FindWithTag("pylonRed").SetActive(true);
            }
            else
            {
                red.SetActive(false);
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


            if (geel == true)
            {
                orange.SetActive(true);
                GameObject.FindWithTag("pylonOrange").SetActive(true);

            }
            else
            {
                orange.SetActive(false);
                GameObject.FindWithTag("pylonOrange").SetActive(false);
            }


            if (zwart == true)
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
