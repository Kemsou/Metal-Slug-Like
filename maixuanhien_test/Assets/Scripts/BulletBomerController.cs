using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomerController : MonoBehaviour {

    [SerializeField]
    float bulletSpeed;

    Rigidbody2D bulletBody;

	// Use this for initialization
	void Start () {
        bulletBody = GetComponent<Rigidbody2D>();
        bulletBody.AddForce(this.transform.right * bulletSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void removeForce() {
        bulletBody.velocity = new Vector2(0, 0);
    }
}
