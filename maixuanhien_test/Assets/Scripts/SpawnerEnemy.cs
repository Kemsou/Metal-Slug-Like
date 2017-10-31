using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour {

    public bool actif;
    private List<Transform> waves;

    [SerializeField]
    private bool isLockingCamera;

	// Use this for initialization
	void Start () {
        waves = new List<Transform>();
        foreach(Transform child in transform)
        {
            waves.Add(child);
        }
    }

    void Update() {
        if (actif)
        {
            int waveFinished = 0;
            foreach(Transform wave in waves)
            {
                WaveEnemyController waveController = wave.GetComponent<WaveEnemyController>();
                if (!waveController.Actif && !waveController.Spent)
                {
                    waveController.Actif = true;
                    break;
                }
                else if(waveController.Actif && !waveController.Spent)
                {
                    break;
                }
                else if (!waveController.Actif && waveController.Spent)
                {
                    waveFinished++;
                }
            }

            if (waveFinished == waves.Count)
            {
                actif = false;
                if (isLockingCamera)
                {
                    Camera.main.GetComponent<cameraFollow>().isLocked = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !actif)
        {
            actif = true;
            if (isLockingCamera)
            {
                Camera.main.GetComponent<cameraFollow>().isLocked = true;
            }
        }
    }
}
