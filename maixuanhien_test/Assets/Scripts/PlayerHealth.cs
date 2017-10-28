using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    int maxHealth;

    [SerializeField]
    public int currentHealth;

    [SerializeField]
    GameObject bloodEffect;
    
    [SerializeField]
    private float frameInvincible;
    private bool isInvincible;
    private float timerInvincible;
    [SerializeField]
    private int delay = 10;
    [SerializeField]
    private GameObject mySpriteRenderer;
    private int counter;
    private bool toggle = false;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        isInvincible = false;
        timerInvincible = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
        {
            makeDead();
        }

        if (isInvincible)
        {
            Flash(mySpriteRenderer);
            if (timerInvincible >= frameInvincible)
            {
                isInvincible = false;
            }
            else
            {
                timerInvincible += Time.deltaTime;
            }
        }
	}

    public void addDamage(int damage) {

        if (damage > 0 && !isInvincible) {
            currentHealth = currentHealth - damage;
            GameObject.Find("playerHUDCanvas/playerArmorUI").GetComponent<ArmorUI>().UpdateAmorUI();
            timerInvincible = 0;
            isInvincible = true;
        }
    }

    public void makeDead() {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        GameObject spawnerPlayer = GameObject.Find("SpawnerPlayer");
        spawnerPlayer.GetComponent<SpawnerPlayer>().SpawnPlayer();
    }

    public void addHealth()
    {
        if (currentHealth <= 2)
        {
            currentHealth++;
            GameObject.Find("playerHUDCanvas/playerArmorUI").GetComponent<ArmorUI>().UpdateAmorUI();
        }
        
    }


    void Flash(GameObject spriteRen)
    {
        
        if (counter >= delay)
        {
            counter = 0;

            toggle = !toggle;
            if (toggle)
            {
                Color newColor = spriteRen.GetComponent<SpriteRenderer>().color;
                newColor.a = 0f;
                spriteRen.GetComponent<SpriteRenderer>().color = newColor;
            }
            else
            {
                Color newColor = spriteRen.GetComponent<SpriteRenderer>().color;
                newColor.a = 1f;
                spriteRen.GetComponent<SpriteRenderer>().color = newColor;
            }

        }
        else
        {
            counter++;
        }
        Debug.Log(counter);
    }
}
