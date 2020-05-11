using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("ms^-1")] [SerializeField] float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        rawYPos = Mathf.Clamp(rawYPos, -3f, 3f);
        float rawNewXPos = transform.localPosition.x + xOffset;
        rawNewXPos = Mathf.Clamp(rawNewXPos, -4.5f, 4.5f);
        transform.localPosition = new Vector3(rawNewXPos , rawYPos, transform.localPosition.z);
        
    }
}
