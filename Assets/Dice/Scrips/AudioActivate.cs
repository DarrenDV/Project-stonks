using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KonamiCode))]
public class AudioActivate : MonoBehaviour
{
    private KonamiCode code;
    public AudioSource Konami;
    public bool Activated;

    void Awake()
    {
        code = GetComponent<KonamiCode>();
        Konami = GetComponent<AudioSource>();
    }

    void Update()
    {
        Konami.Play();
        if (code.success)
        {
                Activated = true;
                Konami.Play();
        }
    }
}
