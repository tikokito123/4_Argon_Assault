using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok if this is the only scripts that load scenes

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    void OnTriggerEnter(Collider other)
    {
        StartDeath();
    }
    private void StartDeath()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }

}
