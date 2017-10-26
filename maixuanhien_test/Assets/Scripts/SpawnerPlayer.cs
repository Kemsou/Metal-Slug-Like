using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject character;

	// Use this for initialization
	void Start () {
        GameObject player = Instantiate(character);
        player.transform.position = this.transform.position;
        GameObject camera = GameObject.Find("Main Camera");
        if (camera != null)
        {
            camera.GetComponent<cameraFollow>().target = player.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
