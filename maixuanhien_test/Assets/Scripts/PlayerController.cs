using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    public float jumpHeight;
    [SerializeField]
    float fireRateBullet = 0.5f;
    [SerializeField]
    float fireRateBeam = 1.0f;
    [SerializeField]
    GameObject _gfxObject = null;
    [SerializeField]
    public bool facingRight;
    [SerializeField]
    public bool grounded;
    bool doublejump;



    //khai bao cac bien de ban
    public Transform gunTip;
    public Transform pivotGunTip;
    public GameObject bullet;
    public GameObject beam;

    private Quaternion rotation;

    float nextFireBullet = 0;
    float nextFireBeam = 0;

    Rigidbody2D charBody;
    Animator charAnimation;

    // Use this for initialization
    void Start() {
        charBody = GetComponent<Rigidbody2D>();
        charAnimation = _gfxObject.GetComponent<Animator>();
        facingRight = true;
        rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update() {

    }

    //FixedUpdate la doi tuong chiu tac dung vat ly

    private void FixedUpdate() {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        if ((facingRight && inputHorizontal == -1) || (!facingRight && inputHorizontal == 1))
            flip();
        Vector2 vecDirection = new Vector2(inputHorizontal, inputVertical);
        changeOrientation(inputHorizontal, inputVertical);

        charBody.velocity = new Vector2(inputHorizontal * maxSpeed, charBody.velocity.y);



        charAnimation.SetFloat("speed", Mathf.Abs(inputHorizontal));

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

        if (Input.GetAxisRaw("Fire2") > 0) {
            fireBeam();
        }
    }

    //xoay huong mat character
    void changeOrientation(float inputHorizontal, float inputVertical) {
        Transform child = transform.GetChild(0);
        if (inputHorizontal == 1 && inputVertical == 1) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 45));
        }
        if (inputHorizontal == 1 && inputVertical == 0) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (inputHorizontal == 1 && inputVertical == -1) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 315));
        }
        if (inputHorizontal == 0 && inputVertical == 1) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (inputHorizontal == 0 && inputVertical == -1) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }
        if (inputHorizontal == -1 && inputVertical == 1) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 135));
        }
        if (inputHorizontal == -1 && inputVertical == 0) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        if (inputHorizontal == -1 && inputVertical == -1) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 225));
        }
        pivotGunTip.transform.rotation = rotation;
    }

    void flip() {
        facingRight = !facingRight;
        Vector2 scale = _gfxObject.transform.localScale;
        scale.x = scale.x * (-1);
        _gfxObject.transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        doublejump = true;
        grounded = false;
    }

    void fireBullet() {
        if (Time.time > nextFireBullet) {
            nextFireBullet = Time.time + fireRateBullet;
            Instantiate(bullet, gunTip.position, pivotGunTip.rotation);
        }
    }


    void fireBeam() {
        if (Time.time > nextFireBeam) {
            nextFireBeam = Time.time + fireRateBeam;
            GameObject childBeam = Instantiate(beam, gunTip.position, gunTip.rotation) as GameObject;
            childBeam.transform.parent = gunTip;
        }
    }
}
