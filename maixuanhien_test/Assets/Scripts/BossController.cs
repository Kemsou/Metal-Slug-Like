using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    [SerializeField]
    private Transform pointLazer;
    [SerializeField]
    private GameObject lazer;
    [SerializeField]
    private GameObject gfx;

    private Transform player;
    private Animator aniBoss;
    private Rigidbody2D bossBody;

    private float attackRate = 3f;
    private float nextAttack = 0;
    private bool playerInSight = false;
    private float timePhrase = 0; // 25 - 30 - 55 - 60 - 70
    private float minX;
    private float maxX;
    private float currentX;

    // Use this for initialization
    void Start() {
        aniBoss = gfx.GetComponent<Animator>();
        bossBody = GetComponent<Rigidbody2D>();
        currentX = transform.localPosition.x;
        minX = currentX - 15;
        maxX = currentX;
    }

    private void FixedUpdate() {
        if (playerInSight == true) {
            attack();
        }
        timePhrase = Time.time%70;
        aniBoss.SetFloat("time", timePhrase);
        currentX = transform.localPosition.x;
        if (timePhrase < 25) {
            if (currentX > minX) {
                bossBody.velocity = new Vector2(-3, bossBody.velocity.y);
            } else {
                bossBody.velocity = new Vector2(0, 0);
            }
        }else if (timePhrase > 30) {
            if(currentX < maxX) {
                bossBody.velocity = new Vector2(3, bossBody.velocity.y);
            } else {
                bossBody.velocity = new Vector2(0, 0);
            }
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
