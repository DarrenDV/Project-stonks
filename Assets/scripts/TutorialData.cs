using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TutorialData", menuName = "Tutorial Data", order = 51)]
public class TutorialData: ScriptableObject
{
    [SerializeField]
    public int counter;
    [SerializeField]
    public int counterMin;
    [SerializeField]
    public int counterMax;
}

