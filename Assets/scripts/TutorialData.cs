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


}
