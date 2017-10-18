using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public float speed;

    Rigidbody2D enemyBody;
    Animator enemyAnimator;

    public GameObject enemyGraphic;

    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    private void Awake() {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponentInChildren<Animator>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextFlip) {
            nextFlip = Time.time + facingTime;
            flip();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            if(facingRight && collision.transform.position.x < transform.position.x) {
                flip();
            }else if(!facingRight && collision.transform.position.x > transform.position.x) {
                flip();
            }
            canFlip = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player") {
            if (!facingRight) {
                enemyBody.AddForce(new Vector2(-1, 0) * speed);
            } else {
                enemyBody.AddForce(new Vector2(1, 0) * speed);
            }
            enemyAnimator.SetBool("run", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player") {
            canFlip = true;
            enemyAnimator.SetBool("run", false);
            enemyBody.velocity = new Vector2(0, 0);
        }
    }

    void flip() {
        if (!canFlip) {
            return;
        }
        facingRight = !facingRight;
        Vector3 scale = enemyGraphic.transform.localScale;
        scale.x = scale.x * (-1);
        enemyGraphic.transform.localScale = scale;
    }
}
