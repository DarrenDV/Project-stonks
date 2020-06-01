using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenesSafer : MonoBehaviour
{
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}