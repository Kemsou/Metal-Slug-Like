﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour {

    private bool actif;
    private List<Transform> waves;

	// Use this for initialization
	void Start () {
        waves = new List<Transform>();
        List<Transform> wavesInversees = new List<Transform>();
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
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !actif)
        {
            actif = true;
        }
    }
}
