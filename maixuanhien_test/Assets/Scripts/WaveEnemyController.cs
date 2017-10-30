using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveEnemyController : MonoBehaviour {
    
    [SerializeField]
    private MultiDimensionalString[] spawner;
    
    private const int SIZE_ELEMENT = 3;
    private int currentWave = 0;
    private float timer;

    [SerializeField]
    private float delay;
    [SerializeField]
    private GameObject kamikaze;
    [SerializeField]
    private GameObject shooter;
    [SerializeField]
    private GameObject runner;
    private bool actif;
    private bool spent;

    public bool Actif
    {
        get
        {
            return actif;
        }

        set
        {
            actif = value;
        }
    }

    public bool Spent
    {
        get
        {
            return spent;
        }

        set
        {
            spent = value;
        }
    }

    // Use this for initialization
    void Start () {
        currentWave = 1;
        timer = delay;
        spent = false;
        actif = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (actif)
        {
            if (timer >= delay && currentWave <= spawner.Length)
            {
                timer = 0;
                SpawnEnemy(currentWave);
                currentWave++;
                
            }
            else
            {
                timer += Time.deltaTime;
            }
            
            if (currentWave >= spawner.Length && transform.childCount == 0)
            {
                actif = false;
                spent = true;
            }
        }
        
    }

    void SpawnEnemy(int currentWave)
    {
        foreach (MultiDimensionalString wave in spawner)
        {
            if (wave.StringArray[0] == currentWave.ToString())
            {
                if (wave.StringArray[1] == "kamikaze")
                {
                    for (int i = 0; i < Convert.ToUInt32(wave.StringArray[2]); i++)
                    {
                        GameObject enemy = Instantiate(kamikaze, transform.position, transform.rotation);
                        enemy.transform.parent = this.transform;
                    }
                }
                if (wave.StringArray[1] == "shooter")
                {
                    for (int i = 0; i < Convert.ToUInt32(wave.StringArray[2]); i++)
                    {
                        GameObject enemy = Instantiate(shooter, transform.position, transform.rotation);
                        enemy.transform.parent = this.transform;
                    }
                }
                if (wave.StringArray[1] == "runner")
                {
                    for (int i = 0; i < Convert.ToUInt32(wave.StringArray[2]); i++)
                    {
                        GameObject enemy = Instantiate(runner, transform.position, transform.rotation);
                        enemy.transform.parent = this.transform;
                    }
                }
            }
        }
    }
}


