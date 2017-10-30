using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    [SerializeField]
    private Transform pointLazer;
    [SerializeField]
    private GameObject lazer;

    private Transform player;

    float attackRate = 2f;
    float nextAttack = 0;
    private bool playerInSight = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        if (playerInSight == true) {
            attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            player = collision.gameObject.transform;
            playerInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            player = null;
            playerInSight = false;
        }
    }

    void attack() {
        if (Time.time > nextAttack) {
            nextAttack = Time.time + attackRate;
            Vector3 vectorToTarget = player.position - pointLazer.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            Instantiate(lazer, pointLazer.position, q);
        }
    }
}
