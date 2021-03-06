﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour {

    [SerializeField]
    private int damage;
    [SerializeField]
    private float pushBackForce;

    float damageRate = 0.5f;
    float nextDamage;

    // Use this for initialization
    void Start() {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time) {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.addDamage(damage);
            nextDamage = damageRate + Time.time;
            pushBack(collision.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time) {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.addDamage(damage);
            nextDamage = damageRate + Time.time;
            pushBack(collision.transform);
        }
    }

    void pushBack(Transform pushObject) {
        Vector2 pushDirection = new Vector2(0, pushObject.position.y - transform.position.y).normalized;
        //Vector2 pushDirection = new Vector2(pushObject.position.x - transform.position.y, pushObject.position.y - transform.position.y).normalized;
        pushDirection = pushDirection * pushBackForce;
        Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
