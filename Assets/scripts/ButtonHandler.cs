using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public int counter = 16;
    public int counterMin = 0;
    public int counterMax = 15;

    public Sprite[] tutorialSprite = new Sprite[24];

    GameObject tutorial;

    // awake wordt gebruikt om te zorgen dat objecten te vinden zijn als ze niet actief zijn
    void Awake()
    {
        tutorial = GameObject.Find("Panel");
    }

    // switch veranderd de achtergrond van de tutorial naar de juiste sprite
    public void Switch()
    {
        tutorial.GetComponent<Image>().sprite = tutorialSprite[counter];
    }

    public void ChangeForward()
    {
        if (counter < counterMax) counter++;
    }

    public void ChangeBackward()
    {
        if (counter > counterMin) counter--;
    }

    //Zet de bankruntext op het aantal geselecteerde bankruns
    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    // zet de tutorial op de juiste achtergrond voor het juiste tutorial onderdeel
    public void SetTutorial(TutorialData tutorialData)
    {
        counter = tutorialData.counter;
        counterMin = tutorialData.counterMin;
        counterMax = tutorialData.counterMax;

        tutorial.GetComponent<Image>().sprite = tutorialSprite[counter];
    }
}