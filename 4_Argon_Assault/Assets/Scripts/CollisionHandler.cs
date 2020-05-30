using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f;
    private void OnTriggerEnter(Collider other)
    {
        StartDeath();
    }

    void StartDeath()
    {
        print("controll frozen!");
        SendMessage("OnPlayerDeath");
    }
}
