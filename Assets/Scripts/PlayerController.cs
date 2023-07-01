using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    float Speed = 4f;
    [SerializeField]
    float xClamp = 4.5f;
    [SerializeField]
    float yClamp = 4.5f;
    [SerializeField] private GameObject[] guns;

    [Header("RotationFactor")]
    [SerializeField]
    float xRotationFactor = -5f;    
    [SerializeField]
    float yRotationFactor = 5f;
    /*[SerializeField]
    float zRotationFactor = 4f;*/

    [Header("RotationMove")]
    [SerializeField]
    float xRotationMove = -10f;    
    [SerializeField]
    float yRotationMove = 10f;
    [SerializeField]
    float zRotationMove = 10f;

    float xMove, yMove;
    bool isControlEnabled = true;
    
    void Update()
    {
        if (isControlEnabled)
        {
            MoveShip();
            RotateShip();
            FireGuns();
        }
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    private void MoveShip()
    {
        // кросплатформенное управление персонажем (с разных платформ)
        xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        yMove = CrossPlatformInputManager.GetAxis("Vertical");


        float xOffset = xMove * Speed * Time.deltaTime;
        float yOffset = yMove * Speed * Time.deltaTime;

        float newXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newXPos, -xClamp, xClamp);

        float newYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(newYPos, -yClamp, yClamp);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    private void RotateShip()
    {
        float xRot = transform.localPosition.y * xRotationFactor + yMove * xRotationMove;
        float yRot = transform.localPosition.x * yRotationFactor + xMove * yRotationMove;
        float zRot = xMove * zRotationMove;
        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    private void FireGuns()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ActiveGuns();
        }
        else
            DeactiveGuns();
    }

    private void DeactiveGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ActiveGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }
}
