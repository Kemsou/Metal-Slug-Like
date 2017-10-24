using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomer : MonoBehaviour {

    public Transform attack;
    public GameObject bullet;

    float attackRate = 1f;
    float nextAttack = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if(collision.tag == "Player") {
    //        attackPlayer(collision);
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player") {
            attackPlayer(collision);
        }
    }

    void attackPlayer(Collider2D collision) {
        if (Time.time > nextAttack) {
            nextAttack = Time.time + attackRate;
            Vector3 vectorToTarget = collision.transform.position - attack.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
   
            GameObject bull = Instantiate(bullet, attack.position, q) as GameObject;
            //Rigidbody2D rigiBull = bull.GetComponent<Rigidbody2D>();
            //Vector2 vec2 = bull.transform.localPosition - collision.transform.localPosition;
            //rigiBull.AddForce(vec2, ForceMode2D.Impulse);
            
        }
    }
}
