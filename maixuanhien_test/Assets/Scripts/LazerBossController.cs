using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBossController : MonoBehaviour {

    [SerializeField]
    float lazerSpeed;

    Rigidbody2D lazerBody;

    // Use this for initialization
    void Start() {
        lazerBody = GetComponent<Rigidbody2D>();
        lazerBody.AddForce(this.transform.right * lazerSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update() {

    }

    void removeForce() {
        lazerBody.velocity = new Vector2(0, 0);
    }
}
