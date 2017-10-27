using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    float maxHealth;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    GameObject bloodEffect;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
        {
            makeDead();
        }
	}

    public void addDamage(float damage) {
        if (damage <= 0) {
            return;
        }
        currentHealth = currentHealth - damage;
    }

    public void makeDead() {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        GameObject spawnerPlayer = GameObject.Find("SpawnerPlayer");
        spawnerPlayer.GetComponent<SpawnerPlayer>().SpawnPlayer();
    }
}
