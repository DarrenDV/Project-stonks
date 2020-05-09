using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Popupscript : MonoBehaviour
{
    public int playerCount;
    public int bankrunCount;
    public bool oranje;
    public bool blauw;
    public bool paars;
    public bool roze;
    public bool grijs;
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
    public void Orange()
    {
        if (oranje == true)
        {
            oranje = false;
            playerCount--;
        }
        else
        {
            oranje = true;
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

    public void Pink()
    {
        if (roze == true)
        {
            roze = false;
            playerCount--;
        }
        else
        {
            roze = true;
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

    public void Grijs()
    {
        if (grijs == true)
        {
            grijs = false;
            playerCount--;
        }
        else
        {
            grijs = true;
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
