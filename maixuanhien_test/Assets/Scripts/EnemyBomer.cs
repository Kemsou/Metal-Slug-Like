using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomer : EnemyController {
    [SerializeField]
    Transform attack;
    [SerializeField]
    GameObject bullet;
    private Transform _player;
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private float fireRateBerserk = 0.7f;
    float nextAttack = 0;
    private bool _isPlayerInSight = false;

    private void FixedUpdate() {
        if (_isPlayerInSight) {
            attackPlayer();
        }

        if (berserk)
        {
            fireRate = fireRateBerserk;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            _player = collision.gameObject.transform;
            _isPlayerInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            _player = null;
            _isPlayerInSight = false;
        }
    }

    void attackPlayer() {
        if (Time.time > nextAttack) {
            nextAttack = Time.time + fireRate;
            Vector3 vectorToTarget = _player.position - attack.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
   
            Instantiate(bullet, attack.position, q);
        }
    }
}
