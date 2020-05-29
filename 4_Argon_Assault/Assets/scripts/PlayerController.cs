using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("ms^-1")] [SerializeField] float speed = 4f;
    [Header("Controll throw")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlPitchFactor = -5f;
    bool isControlEnabled = true;
    float xThrow, yThrow;
    void Update()
    {
        if (isControlEnabled)
        {
            ProccesTranslation();
            ProccesRotation();
        }
    }
    void OnPlayerDeath() // called by string reference!
    {
        print("controll frozen!");
        isControlEnabled = false;
    }

    private void ProccesRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlPitchFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
    }

    private void ProccesTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        rawYPos = Mathf.Clamp(rawYPos, -4f, 4f);
        float rawNewXPos = transform.localPosition.x + xOffset;
        rawNewXPos = Mathf.Clamp(rawNewXPos, -6f, 6f);
        transform.localPosition = new Vector3(rawNewXPos, rawYPos, transform.localPosition.z);
    }
}
