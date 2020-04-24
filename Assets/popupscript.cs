using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupscript : MonoBehaviour
{
    public int playerCount = 0;
    public bool rood;
    public bool blauw;
    public bool paars;
    public bool geel;
    public bool zwart;
    public bool groen;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void setPlayerCount(int playerCount)
    {
        this.playerCount = playerCount;
    }

    public int getPlayerCount()
    {
        return playerCount;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Rood() {
        if (rood == true) {
            rood = false;
            playerCount--;
        }
        else
        {
            rood = true;
            playerCount++;
        }
    }

    public void Blauw()
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

    public void Geel()
    {
        if (geel == true)
        {
            geel = false;
            playerCount--;
        }
        else
        {
            geel = true;
            playerCount++;
        }
    }

    public void Paars()
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

    public void Zwart()
    {
        if (zwart == true)
        {
            zwart = false;
            playerCount--;
        }
        else
        {
            zwart = true;
            playerCount++;
        }
    }

    public void Groen()
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
