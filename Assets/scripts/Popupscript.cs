using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

public class Popupscript : MonoBehaviour
{

    public int playerCount;
    public int bankrunCount;
    
    public bool bordActive;
    public Slider bankrunSlider;
    public Text text;
    public Button spel;
    public Button tutorialChooseB;
    public Button back;
    public GameObject minDrie;

    GameObject cameraBord;
    GameObject cameraTutorial;
    GameObject lichtTutorial;
    GameObject canvas;

    public GameObject panel;
    public GameObject tutorialChoose;

    public Toggle[] toggleArray = new Toggle[5];

    static int MIN_PLAYERS = 3;

    // Start wordt aangeroepen voor het eerste frame
    void Start()
    {
        panel.gameObject.SetActive(false);
        tutorialChoose.SetActive(false);

        bankrunSlider = GameObject.Find("BankrunCount").GetComponent<Slider>();
        text = GameObject.Find("BankrunText").GetComponent<Text>();
        spel = GameObject.Find("Spel").GetComponent<Button>();

        toggleArray = FindObjectsOfType<Toggle>();
    }

    // Update wordt 1x per frame aangeroepen
    void FixedUpdate()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "bord")
        {
            bankrunCount = (int)bankrunSlider.value;
            text.text = text.text = bankrunCount.ToString() + " Bankruns";
        }
        if (playerCount < MIN_PLAYERS)
        {
            // buttons werken niet bij minder dan drie spelers
            spel.enabled = false;
            tutorialChooseB.enabled = false;
            minDrie.SetActive(true);
        }
        else
        {
            spel.enabled = true;
            tutorialChooseB.enabled = true;
            minDrie.SetActive(false);
        }
    }

    public void ToggleValueChanged(Toggle changed)
    {
        if (changed.isOn == true)
        {
            playerCount++;
        }
        else
        {
            playerCount--;
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