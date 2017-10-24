using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target; //target character
    public float smoothing; //giam giat (giam rung) camera

    float minX;
    float minY;
    float offset;

    // Use this for initialization
    void Start() {
        minX = transform.position.x;
        offset = transform.position.y - target.position.y;
        minY = -12;
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        Vector3 targetCameraPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing * Time.deltaTime);
    }
}
