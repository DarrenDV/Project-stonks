using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDisable : MonoBehaviour
{
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "bord")
        {
            this.gameObject.SetActive(false);
        }
    }
}