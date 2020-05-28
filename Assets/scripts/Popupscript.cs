using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using System.Collections.Specialized;

public class Popupscript : MonoBehaviour
{
    public int playerCount;
    public int bankrunCount;
    public bool oranje;
    public bool blauw;
    public bool paars;
    public bool roze;
    public bool grijs;
    public bool groen;
    public bool bordActive;
    public Slider bankrunSlider;
    public Text text;
    public Button button;
    public Button tutorial;
    public Button spel;
    public Button bankrun;
    public Button promote;

    GameObject CameraBord;
    GameObject CameraTutorial;
    GameObject LichtTutorial;
    GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        bankrunSlider = GameObject.Find("BankrunCount").GetComponent<Slider>();
        text = GameObject.Find("BankrunText").GetComponent<Text>();
        button = GameObject.Find("Spel").GetComponent<Button>();
        // tutorial = GameObject.Find("Tutorial").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "bord")
        {
           //this.gameObject.SetActive(false);
        }
        else
        {
            bankrunCount = (int)bankrunSlider.value;
            text.text = text.text = bankrunCount.ToString() + " Bankruns";
        }
        if (playerCount<3)
        {
            button.enabled = false;
            tutorial.enabled = false;
            spel.enabled = false;
            bankrun.enabled = false;
            promote.enabled = false;
        }
        else
        {
            button.enabled = true;
            tutorial.enabled = true;
            spel.enabled = true;
            bankrun.enabled = true;
            promote.enabled = true;
        }
    }

    public void Orange()
    {
        if (!bordActive)
        {
            if (oranje == true)
            {
                oranje = false;
                playerCount--;
            }
            else
            {
                oranje = true;
                playerCount++;
            }
        }
    }

    public void Blauw()
    {
        if (!bordActive)
        {
            if (blauw == true)
            {
                blauw = false;
                playerCount--;
            }
            else
            {
                blauw = true;
                playerCount++;
            }
        }
    }

    public void Pink()
    {
        if (!bordActive)
        {
            if (roze == true)
            {
                roze = false;
                playerCount--;
            }
            else
            {
                roze = true;
                playerCount++;
            }
        }
    }

    public void Paars()
    {
        if (!bordActive)
        {
            if (paars == true)
            {
                paars = false;
                playerCount--;
            }
            else
            {
                paars = true;
                playerCount++;
            }
        }
    }

    public void Grijs()
    {
        if (!bordActive)
        {
            if (grijs == true)
            {
                grijs = false;
                playerCount--;
            }
            else
            {
                grijs = true;
                playerCount++;
            }
        }
    }

    public void Groen()
    {
        if (!bordActive)
        {
            if (groen == true)
            {
                groen = false;
                playerCount--;
            }
            else
            {
                groen = true;
                playerCount++;
            }
        }
    }
    private void Awake()
    {
        CameraTutorial = GameObject.Find("Main CameraT");
        LichtTutorial = GameObject.Find("Directional Light");
        Canvas = GameObject.Find("Canvas");
    }

    public void switchScreen()
    {
        if (playerCount > 2 && !bordActive)
        {
            SceneManager.LoadScene("bord");
            bordActive = true;
        }
        else if (bordActive)
        {
            CameraTutorial.gameObject.SetActive(false);
            LichtTutorial.gameObject.SetActive(false);
            Canvas.gameObject.SetActive(false);
            //CameraBord.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
