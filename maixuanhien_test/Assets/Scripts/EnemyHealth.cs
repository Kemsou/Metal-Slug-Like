using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private GameObject enemyHealthEF;
    [SerializeField]
    private Slider enemyHealthSlider;
    [SerializeField]
    private GameObject gfx;

    private Animator aniBoss;

    private float currentHealth;
    private bool _isBerSerk = false;
    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;

        aniBoss = gfx.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage) {
        currentHealth = currentHealth - damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0) {
            isBerSerk();
        }
    }

    void isBerSerk() {
        _isBerSerk = true;
        enemyHealthSlider.gameObject.SetActive(false);
    }
    public void makeDead() {
        aniBoss.Play("PatternPhase3_1");
        Destroy(gameObject);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
