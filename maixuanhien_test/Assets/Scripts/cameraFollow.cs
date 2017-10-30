﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform target; //target character
    public float smoothing; //giam giat (giam rung) camera

    [SerializeField]
    private float minX = 5;
    [SerializeField]
    private float maxX = 90;
    [SerializeField]
    private float minY = -5;
    [SerializeField]
    private float maxY = 5;

    [SerializeField]
    private bool isLocked = false;


    float offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position.y - target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), Color.red);
        Debug.DrawLine(new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), Color.red);
        Debug.DrawLine(new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), Color.red);
        Debug.DrawLine(new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), Color.red);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (!isLocked)
            {
                Vector3 targetCameraPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
                Vector3 newPos = targetCameraPosition;

                if (targetCameraPosition.x < minX)
                {
                    newPos.x = minX;
                }

                if (targetCameraPosition.x > maxX)
                {
                    newPos.x = maxX;
                }

                if (targetCameraPosition.y < minY)
                {
                    newPos.y = minY;
                }

                if (targetCameraPosition.y > maxY)
                {
                    newPos.y = maxY;
                }


                //transform.position = Vector3.Lerp(transform.position, newPos, smoothing * Time.deltaTime);
                transform.position = newPos;
            }
        }
        checkIfInsideCameraBox();
    }

    public void lockCamera()
    {
        this.isLocked = true;
    }

    public void unlockCamera()
    {
        this.isLocked = false;
    }

    //Check if the player is inside the camera box. If not, it changes it position to make it so or kill him if he fall.
    private void checkIfInsideCameraBox()
    {
        Vector3 playerPositionCamera = Camera.main.WorldToScreenPoint(target.position);
        if (target != null)
        {
            if(playerPositionCamera.x < 0)
            {
                target.position = Camera.main.ScreenToWorldPoint(new Vector3(0, playerPositionCamera.y, playerPositionCamera.z));
            } else if (playerPositionCamera.x > Camera.main.pixelWidth)
            {
                target.position = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, playerPositionCamera.y, playerPositionCamera.z));
            }
            if(playerPositionCamera.y < 0)
            {
                target.GetComponent<PlayerHealth>().makeDead();
            }
        }
    }

}
