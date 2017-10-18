using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    public float jumpHeight;
    public float jumpPower;

    bool facingRight;
    bool grounded;
    bool doublejump;

    //khai bao cac bien de ban
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    Rigidbody2D charBody;
    Animator charAnimation;

    // Use this for initialization
    void Start() {
        charBody = GetComponent<Rigidbody2D>();
        charAnimation = GetComponent<Animator>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update() {

    }

    //FixedUpdate la doi tuong chiu tac dung vat ly

    private void FixedUpdate() {
        float move = Input.GetAxisRaw("Horizontal");

        charBody.velocity = new Vector2(move * maxSpeed, charBody.velocity.y);

        if (move > 0 && !facingRight) {
            flip();
        } else if (move < 0 && facingRight) {
            flip();
        }

        charAnimation.SetFloat("speed", Mathf.Abs(move));

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grounded) {
                grounded = false;
                //charBody.velocity = new Vector2(charBody.velocity.x, 0);
                charBody.velocity = new Vector2(charBody.velocity.x, jumpHeight);
                //charBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                //charBody.AddForce(Vector2.up * jumpPower);
                doublejump = true;
            } else {
                if (doublejump) {
                    doublejump = false;
                    charBody.velocity = new Vector2(charBody.velocity.x, 0);
                    charBody.velocity = new Vector2(charBody.velocity.x, jumpHeight * (float)0.75);
                    //charBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                    //charBody.AddForce(Vector2.up * jumpPower);
                }
            }

        }

        //chuc nang ban tu ban phim
        if (Input.GetAxisRaw("Fire1") > 0) {
            fireBullet();
        }
    }

    //xoay huong mat character
    void flip() {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x = scale.x * (-1);
        transform.localScale = scale;
    }

    //va cham mat dat
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        doublejump = true;
        grounded = false;
    }

    //chuc nang ban
    void fireBullet() {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            if (facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            } else {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
