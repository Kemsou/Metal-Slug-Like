using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    [SerializeField]
    private Transform linkedSpawner;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(linkedSpawner != null && linkedSpawner.gameObject.GetComponent<SpawnerEnemy>())
        {
            if (linkedSpawner.gameObject.GetComponent<SpawnerEnemy>().actif)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
	}
}
