using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 7.5f;
    [SerializeField] float posPitchFactor = -10f;       // x Rotation -6 to 11
    [SerializeField] float posYawFactor = 10f;         // y Rotation -18 to 21
    
    [SerializeField] float controlPitchFactor = -80f;
    [SerializeField] float controlRollFactor = -80f;
    float xThrow = 0f , yThrow = 0f;

    [SerializeField] GameObject[] guns; 

    bool isControlledEnabled = true;

    void Update()
    {
        if (isControlledEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    public void ProcessFiring()
    {
          if(CrossPlatformInputManager.GetButton("Fire"))
        {
            foreach(GameObject gun in guns)
            {
                gun.SetActive(true);
            }
        }
          else
        {
            foreach (GameObject gun in guns)
            {
                gun.SetActive(false);
            }
        }
    }

    void OnPlayerDeath()
    {
        isControlledEnabled = false;
    }
    void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawXPos, -4f, 4f);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawYPos, -2.3f, 2.3f);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * posPitchFactor + yThrow * controlPitchFactor;   
        float yaw = transform.localPosition.x * posYawFactor ;
        float roll = xThrow * controlRollFactor ;
        transform.localRotation = Quaternion.Euler(pitch, yaw,roll);    
    }

}
