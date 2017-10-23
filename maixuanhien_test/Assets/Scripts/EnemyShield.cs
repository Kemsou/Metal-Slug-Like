using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiShield : MonoBehaviour {
    
    float currentShield;
    
    [SerializeField]
    float maxShield;
    [SerializeField]
    GameObject enemyShieldEF;
    [SerializeField]
    Slider enemyShieldSlider;
    


	// Use this for initialization
	void Start () {
        currentShield = maxShield;
        enemyShieldSlider.maxValue = maxShield;
        enemyShieldSlider.value = maxShield;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage) {
        currentShield = currentShield - damage;
        enemyShieldSlider.value = currentShield;
        if (currentShield <= 0) {
            makeDead();
        }
    }

    void makeDead() {
        Destroy(gameObject);
        Instantiate(enemyShieldEF, transform.position, transform.rotation);
    }

    void makeBerserk()
    {
        Destroy(gameObject);
        Instantiate(enemyShieldEF, transform.position, transform.rotation);
    }
}
