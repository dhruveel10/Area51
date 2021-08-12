using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadSplashScene", 3.5f);
    }


    void LoadSplashScene()
    {
        SceneManager.LoadScene(1);
    }

}
