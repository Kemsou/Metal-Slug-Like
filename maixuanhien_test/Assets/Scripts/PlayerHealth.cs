using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;

    float currentHealth;

    public GameObject bloodEffect;
    //public Slider playerHealthSlider;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        //playerHealthSlider.maxValue = maxHealth;
        //playerHealthSlider.value = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage) {
        if (damage <= 0) {
            return;
        }
        currentHealth = currentHealth - damage;
        //playerHealthSlider.value = currentHealth;
        if (currentHealth <= 0) {
            makeDead();
        }
    }

    void makeDead() {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
