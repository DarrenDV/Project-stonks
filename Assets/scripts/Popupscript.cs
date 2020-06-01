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
    public Button tutorialChooseB;
    public Button back;
    public GameObject minDrie;
    GameObject cameraBord;
    GameObject cameraTutorial;
    GameObject lichtTutorial;
    GameObject canvas;
    public GameObject panel;
    public GameObject tutorialChoose;

    // Start wordt aangeroepen voor het eerste frame
    void Start()
    {
        panel.gameObject.SetActive(false);
        tutorialChoose.SetActive(false);

        bankrunSlider = GameObject.Find("BankrunCount").GetComponent<Slider>();
        text = GameObject.Find("BankrunText").GetComponent<Text>();
        button = GameObject.Find("Spel").GetComponent<Button>();
    }

    // Update wordt 1x per frame aangeroepen
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "bord")
        {
            bankrunCount = (int)bankrunSlider.value;
            text.text = text.text = bankrunCount.ToString() + " Bankruns";
        }
        if (playerCount < 3)
        {
            // buttons werken niet bij minder dan drie spelers
            button.enabled = false;
            tutorial.enabled = false;
            spel.enabled = false;
            bankrun.enabled = false;
            promote.enabled = false;
            tutorialChooseB.enabled = false;
            minDrie.SetActive(true);
        }
        else
        {
            button.enabled = true;
            tutorial.enabled = true;
            spel.enabled = true;
            bankrun.enabled = true;
            promote.enabled = true;
            tutorialChooseB.enabled = true;
            minDrie.SetActive(false);
        }
    }

    // kleuren om aan het bord door te geven hoeveel spelers er mee spelen
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

    // awake wordt gebruikt om te zorgen dat objecten te vinden zijn als ze niet actief zijn
    private void Awake()
    {
        cameraTutorial = GameObject.Find("Main CameraT");
        lichtTutorial = GameObject.Find("Directional Light");
        canvas = GameObject.Find("Canvas");
    }

    // verandert de scene naar het bord
    public void SwitchScreen()
    {
        if (playerCount > 2 && !bordActive)
        {
            SceneManager.LoadScene("bord");
            bordActive = true;
            back.enabled = false;
        }
        else if (bordActive)
        {
            cameraTutorial.gameObject.SetActive(false);
            lichtTutorial.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}