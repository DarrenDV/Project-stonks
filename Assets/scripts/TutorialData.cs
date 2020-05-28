using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TutorialData", menuName = "Tutorial data", order = 51)]
public class TutorialData : ScriptableObject
{
    [SerializeField]
    private int counter;
    [SerializeField]
    private int counterMin;
    [SerializeField]
    private int counterMax;


    public int getCounter
    {
        get
        {
            return counter;
        }
    }

    public int getCounterMin
    {
        get
        {
            return counterMin;
        }
    }

    public int getCounterMax
    {
        get
        {
            return counterMax;
        }
    }

    public void tutorialSetup()
    {
        counter = 0;
        counterMin = 0;
        counterMax = 4;
    }

    public void tutorialSpel()
    {
        counter = 5;
        counterMin = 5;
        counterMax = 15;
    }
    public void tutorialBankrunl()
    {
        counter = 16;
        counterMin = 16;
        counterMax = 19;
    }
    public void tutorialPromote()
    {
        counter = 20;
        counterMin = 20;
        counterMax = 23;
    }
}
