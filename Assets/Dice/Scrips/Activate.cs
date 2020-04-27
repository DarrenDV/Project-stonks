using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KonamiCode))]
public class Activate : MonoBehaviour
{
    private KonamiCode code;
    public bool Activated;
    public GameObject plane;

    void Awake()
    {
        code = GetComponent<KonamiCode>();
    }

    void Update()
    {
        if (code.success)
        {
                Activated = true;
        }
        if (Activated == true){
            plane.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                plane.SetActive(false);
                code.success = false;
                Activated = false;
            }
        }
    }
}
