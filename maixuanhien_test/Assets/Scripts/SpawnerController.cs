using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour {
    
    public MultiDimensionalString[] ennemisArray;
    
    private const int SIZE_ELEMENT = 3;
    private int currentWave = 0;
    private float timer;

    [SerializeField]
    private float delay;
    [SerializeField]
    private GameObject kamikaze;

    // Use this for initialization
    void Start () {
        currentWave = 0;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
		if (currentWave != 0 && timer == 0)
        {
            SpawnEnemy(currentWave);
        }

        if (timer >= delay && currentWave != 0)
        {
            timer = 0;
            currentWave++;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }

    void OnValidate()
    {
        foreach (MultiDimensionalString ennemi in ennemisArray)
        {
            if (ennemi.StringArray.Length != 3)
            {
                Debug.LogWarning("Don't change the 'Element' field's array size!");
                //Array.Resize(ennemi.StringArray, 3);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && currentWave == 0)
        {
            TriggerSpawner();
            Debug.Log("trigger");
        }
    }

    void TriggerSpawner()
    {
        Debug.Log("trigger");
        currentWave = 1;
        timer = 0;
    }

    void SpawnEnemy(int currentWave)
    {
        foreach(MultiDimensionalString wave in ennemisArray)
        {
            if (wave.StringArray[0] == currentWave.ToString())
            {
                if (wave.StringArray[1] == "kamikaze")
                {
                    for (int i = 0; i < Convert.ToUInt32(wave.StringArray[2]); i++)
                    {
                        Instantiate(kamikaze, transform.position, transform.rotation);
                    }

                }
            }
        }
    }
}


