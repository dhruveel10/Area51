using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 3f;
    [SerializeField]GameObject deathVFX ;    

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathVFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }
    void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}

