using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Effects;

public class PlayerController : MonoBehaviour
{
    [Header ("General")]
    [Tooltip("ms^-1")] [SerializeField] float speed = 4f;
    [Header("Screen position")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] GameObject[] guns;
    float xThrow, yThrow;
    bool isControlEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProccesTranslation();
            ProccesRotation();
            ProccesFiring();
        }
    }
    void OnPlayerDeath()
    {
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
        rawYPos = Mathf.Clamp(rawYPos, -3.5f, 3.5f);
        float rawNewXPos = transform.localPosition.x + xOffset;
        rawNewXPos = Mathf.Clamp(rawNewXPos, -4f, 4f);
        transform.localPosition = new Vector3(rawNewXPos, rawYPos, transform.localPosition.z);
    }
    void ProccesFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActivate(true);
        }
        else
        {
            SetGunsActivate(false);
        }
        
    }
    private void SetGunsActivate(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionMudle = gun.GetComponent<ParticleSystem>().emission;
            emissionMudle.enabled = isActive;
        }
    }
}
