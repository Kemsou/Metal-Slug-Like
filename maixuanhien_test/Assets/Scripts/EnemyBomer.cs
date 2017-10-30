using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomer : MonoBehaviour {
    [SerializeField]
    Transform attack;
    [SerializeField]
    GameObject bullet;
    private Transform _player;

    float attackRate = 1f;
    float nextAttack = 0;
    private bool _isPlayerInSight = false;

    private void FixedUpdate() {
        if (_isPlayerInSight) {
            attackPlayer();
        }

        //RaycastHit hit;
        //if (Physics.Raycast(attack.transform.position, player.transform.position, out hit, 100.0f)) {
        //    Debug.Log("Ray");
        //    attackPlayer(player);
        //}
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
            nextAttack = Time.time + attackRate;
            Vector3 vectorToTarget = _player.position - attack.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
   
            Instantiate(bullet, attack.position, q);
        }
    }
}
