using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{  public int counter = 0;

    Image myImageComponent;

    public Sprite tutorial1;
    public Sprite tutorial2;
    public Sprite tutorial3;
    public Sprite tutorial4;
    public Sprite tutorial5;

    void Start()
    {
        myImageComponent = GetComponent<Image>();
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
        }
    }

    public void ChangeForward()
    {
        counter++;
    }

    public void ChangeBackward()
    {
        if(counter >0) counter--;
    }

    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }
}