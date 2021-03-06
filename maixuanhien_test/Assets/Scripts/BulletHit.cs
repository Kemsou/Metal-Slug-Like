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
        bool destroy = false;
        if (collision.gameObject.tag == "ShootTable")
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                if (!collision.gameObject.transform.parent.GetComponent<EnemyController>().isBerserk)
                {
                    destroy = true;
                    EnemyController hurtEnemy;
                    hurtEnemy = collision.gameObject.GetComponentInParent<EnemyController>();
                    hurtEnemy.addDamage(weaponDamage);
                }
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("destructible"))
            {
                destroy = true;
                EnemyHealth hurtEnemy;
                hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            } else if (collision.gameObject.layer == LayerMask.NameToLayer("boss")) {
                destroy = true;
                EnemyHealth hurtEnemy;
                hurtEnemy = collision.gameObject.GetComponentInParent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
        else if (collision.gameObject.tag == "Ground" && collision.gameObject.GetComponent<PlatformEffector2D>().useOneWay == false)
        {
            destroy = true;
        }

        if (destroy)
        {
            proCon.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        bool destroy = false;
        if (collision.gameObject.tag == "ShootTable")
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                if (!collision.gameObject.transform.parent.GetComponent<EnemyController>().isBerserk)
                {
                    destroy = true;
                    EnemyController hurtEnemy;
                    hurtEnemy = collision.gameObject.GetComponentInParent<EnemyController>();
                    hurtEnemy.addDamage(weaponDamage);
                }
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("destructible"))
            {
                destroy = true;
                EnemyHealth hurtEnemy;
                hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
        else if (collision.gameObject.tag == "Ground" && collision.gameObject.GetComponent<PlatformEffector2D>().useOneWay == false)
        {
            destroy = true;
        }

        if (destroy)
        {
            proCon.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
