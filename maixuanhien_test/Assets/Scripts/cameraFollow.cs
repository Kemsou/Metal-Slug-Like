using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

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

    float offset;

    // Use this for initialization
    void Start() {
        offset = transform.position.y - target.position.y;

        //float vertExtent = this.GetComponent<Camera>().orthographicSize;
        //float horzExtent = vertExtent * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update() {
        Debug.DrawLine(new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), Color.red);
        Debug.DrawLine(new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), Color.red);
        Debug.DrawLine(new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), new Vector3(minX - this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), Color.red);
        Debug.DrawLine(new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, minY - this.GetComponent<Camera>().orthographicSize, 0), new Vector3(maxX + this.GetComponent<Camera>().orthographicSize * 16 / 9, maxY + this.GetComponent<Camera>().orthographicSize, 0), Color.red);
    }

    private void FixedUpdate() {
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

        
        transform.position = Vector3.Lerp(transform.position, newPos, smoothing * Time.deltaTime);
    }
}
