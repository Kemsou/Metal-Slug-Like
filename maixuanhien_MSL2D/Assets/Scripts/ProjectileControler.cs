using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour {

    public float bulletSpeed;

    Rigidbody2D bulletBody;

    //awake goi truoc start
    private void Awake() {
        bulletBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0) {
            bulletBody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        } else {
            bulletBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
