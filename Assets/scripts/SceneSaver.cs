using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    //Merged beide scenes in een DontDestroyOnLoad()
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}