using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
    //Float for max time to wait
    private const float WaitTime = 0.5f;

    //KonamiCode in order
    private KeyCode[] keys = new KeyCode[]
    {
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.B,
        KeyCode.A
    };

    public bool success;

    public bool Activated;
    public GameObject plane;

    IEnumerator Start()
    {
        float timer = 0f;
        int index = 0;

        while (true)
        {
            if (Input.GetKeyDown(keys[index]))
            {
                index++;

                if (index == keys.Length)
                {
                    success = true;
                    timer = 0f;
                    index = 0;
                }
                else
                {
                    timer = WaitTime;
                }
            }
            else if (Input.anyKeyDown)
            {
                // print("Wrong key in sequence.");
                timer = 0;
                index = 0;
            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    timer = 0;
                    index = 0;
                }
            }

            yield return null;
        }
    }

    void Update()
    {
        if (success)
        {
            Activated = true;
        }
        if (Activated == true)
        {
            plane.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                plane.SetActive(false);
                success = false;
                Activated = false;
            }
        }
    }
}
