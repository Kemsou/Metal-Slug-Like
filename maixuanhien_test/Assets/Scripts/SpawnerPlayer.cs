using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject character;
    private List<Transform> checkpoints;
    private Transform currentCheckpoint;

	// Use this for initialization
	void Start () {
        

        checkpoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            checkpoints.Add(child);
        }
        currentCheckpoint = this.transform;
        currentCheckpoint.GetComponent<Checkpoint>().SpawnPlayer(character);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void SpawnPlayer()
    {
        currentCheckpoint.GetComponent<Checkpoint>().SpawnPlayer(character);
    }

    public void ChangeCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }
}
