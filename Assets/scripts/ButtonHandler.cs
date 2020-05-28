using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    public TutorialData tutorialData;
    public int counter = 16;
    public int counterMin = 0;
    public int counterMax = 15;

    Image myImageComponent;

    public Sprite tutorial1;
    public Sprite tutorial2;
    public Sprite tutorial3;
    public Sprite tutorial4;
    public Sprite tutorial5;
    public Sprite tutorial6;
    public Sprite tutorial7;
    public Sprite tutorial8;
    public Sprite tutorial9;
    public Sprite tutorial10;
    public Sprite tutorial11;
    public Sprite tutorial12;
    public Sprite tutorial13;
    public Sprite tutorial14;
    public Sprite tutorial15;
    public Sprite tutorial16;
    public Sprite tutorial17;
    public Sprite tutorial18;
    public Sprite tutorial19;
    public Sprite tutorial20;
    public Sprite tutorial21;
    public Sprite tutorial22;
    public Sprite tutorial23;
    public Sprite tutorial24;

    GameObject turorial;

    void Start()
    {
        myImageComponent = GetComponent<Image>();
    }
    void Awake()
    {
        turorial = GameObject.Find("Panel");
    }

        public void Init(TutorialData tutorialData)
    {
        counter = tutorialData.getCounter;
        counterMin = tutorialData.getCounterMin;
        counterMax = tutorialData.getCounterMax;
    }

    public void Switch()
    {
        switch (counter)
        {
            case 0:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial1;
                break;
            case 1:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial2;
                break;
            case 2:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial3;
                break;
            case 3:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial4;
                break;
            case 4:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial5;
                break;
            case 5:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial6;
                break;
            case 6:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial7;
                break;
            case 7:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial8;
                break;
            case 8:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial9;
                break;
            case 9:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial10;
                break;
            case 10:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial11;
                break;
            case 11:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial12;
                break;
            case 12:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial13;
                break;
            case 13:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial14;
                break;
            case 14:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial15;
                break;
            case 15:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial16;
                break;
            case 16:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial17;
                break;
            case 17:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial18;
                break;
            case 18:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial19;
                break;
            case 19:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial20;
                break;
            case 20:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial21;
                break;
            case 21:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial22;
                break;
            case 22:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial23;
                break;
            case 23:
                GameObject.Find("Panel").GetComponent<Image>().sprite = tutorial24;
                break;
        }
        counter++;
        counter--;
    }

    public void ChangeForward()
    {
        if (counter < counterMax) counter++;
    }

    public void ChangeBackward()
    {
        if (counter > counterMin) counter--;
    }

    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    public void TutorialSetup()
    {
        counter = 0;
        counterMin = 0;
        counterMax = 4;
    }
    public void TutorialSpel()
    {
        counter = 5;
        counterMin = 5;
        counterMax = 15;
    }
    public void TutorialBankrun()
    {
        
        counter = 16;
        counterMin = 16;
        counterMax = 19;
        turorial.GetComponent<Image>().sprite = tutorial17;

    }
    public void Tutorialpromote()
    {
        counter = 20;
        counterMin = 20;
        counterMax = 23;
    }
}