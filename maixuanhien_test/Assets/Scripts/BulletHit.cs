﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

    ProjectileControler proCon;

    public GameObject bulletExplosion;
    public float weaponDamage;

    private void Awake() {
        proCon = GetComponentInParent<ProjectileControler>();
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "ShootTable" && !collision.gameObject.transform.parent.GetComponent<EnemyController>().isBerserk) {
            proCon.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy")) {
                EnemyController hurtEnemy = collision.gameObject.GetComponentInParent<EnemyController>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "ShootTable" && !collision.gameObject.transform.parent.GetComponent<EnemyController>().isBerserk) {
            proCon.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy")) {
                EnemyController hurtEnemy = collision.gameObject.GetComponentInParent<EnemyController>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}
