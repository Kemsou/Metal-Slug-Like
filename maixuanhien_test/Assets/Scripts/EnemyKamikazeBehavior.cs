﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikazeBehavior : EnemyController {

    // Use this for initialization
    /*void Start () {
        currentShield = maxShield;
        enemyShieldSlider.maxValue = maxShield;
        enemyShieldSlider.value = maxShield;
        Debug.Log("currentShield : " + currentShield);
    }*/

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (facingRight && collision.transform.position.x < transform.position.x) {
                flip();
            } else if (!facingRight && collision.transform.position.x > transform.position.x) {
                flip();
            }
            canFlip = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (!facingRight) {
                enemyBody.velocity = new Vector2(-1 * speed, enemyBody.velocity.y);
            } else {
                enemyBody.velocity = new Vector2(1 * speed, enemyBody.velocity.y);
            }
            enemyAnimator.SetBool("run", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            canFlip = true;
            enemyAnimator.SetBool("run", false);
            enemyBody.velocity = new Vector2(0, 0);
        }
    }
}
