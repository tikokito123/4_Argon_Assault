using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeath();
        Invoke("RestartScene", levelLoadDelay);
    }

    void StartDeath()
    {
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath");
    }
    void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
}
