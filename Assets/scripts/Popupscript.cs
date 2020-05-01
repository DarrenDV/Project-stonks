using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Popupscript : MonoBehaviour
{
    public int playerCount;
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

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "bord")
        {
            this.gameObject.SetActive(false);
        }

    }
    /*
    public void setPlayerCount(int playerCount)
    {
        this.playerCount = playerCount;
    }

    public int getPlayerCount()
    {
        return playerCount;
        .material.color = new Color
    }
    */
    public void Rood()
    {
        if (rood == true)
        {
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
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
