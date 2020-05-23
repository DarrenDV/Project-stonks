using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenesSafer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        /*
        if (scene.name == "bord")
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("bord"));
        }
        else if(scene.name == "TutorialScene")
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("TutorialScene"));
        }
        */

    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
