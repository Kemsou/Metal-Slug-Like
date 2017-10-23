using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth;

    float currentHealth;

    public GameObject enemyHealthEF;
    public Slider enemyHealthSlider;


	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage) {
        currentHealth = currentHealth - damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0) {
            makeDead();
        }
    }

    void makeDead() {
        Destroy(gameObject);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
