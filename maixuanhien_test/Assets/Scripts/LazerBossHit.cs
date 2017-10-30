using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBossHit : MonoBehaviour {

    [SerializeField]
    GameObject LazerBossExplosion;
    [SerializeField]
    int damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Instantiate(LazerBossExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.addDamage(damage);
        }
    }
}
