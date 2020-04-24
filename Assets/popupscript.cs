using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupscript : MonoBehaviour
{
    int playerCount = 0;
   public List<string> colors = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setPlayerCount(int playerCount)
    {
        this.playerCount = playerCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void colorPick(string color) 
    {
        foreach (var knownColor in colors)
        {
            if (string.Equals(knownColor, color))
            {

            }
            else
            {
                colors.Add(color);
            }
        }
        if (colors.Count == 0)
        {
            colors.Add(color);
        }

    }
}
