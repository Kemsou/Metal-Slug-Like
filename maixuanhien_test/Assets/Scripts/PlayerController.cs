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
    private List<Collision2D> _groundCollisions = new List<Collision2D>();

    bool _hasDoubleJumped;
    [SerializeField]
    private bool manette;
    private float inputHorizontal;
    private float inputVertical;

    public Transform gunTip;
    public Transform pivotGunTip;
    public GameObject bullet;
    public GameObject beam;
    [SerializeField]
    private bool hasGunShieldBreaker;
    [SerializeField]
    private bool hasGunBeam;
    [SerializeField]
    private float durationBeam;
    private float timerBeam;

    private Quaternion rotation;

    float nextFireBullet = 0;
    float nextFireBeam = 0;

    Rigidbody2D charBody;
    Animator charAnimation;

    public bool HasGunShieldBreaker
    {
        get
        {
            return hasGunShieldBreaker;
        }

        set
        {
            hasGunShieldBreaker = value;
        }
    }

    public bool HasGunBeam
    {
        get
        {
            return hasGunBeam;
        }

        set
        {
            hasGunBeam = value;
        }
    }

    // Use this for initialization
    void Start() {
        charBody = GetComponent<Rigidbody2D>();
        charAnimation = _gfxObject.GetComponent<Animator>();
        facingRight = true;
        rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        inputHorizontal = 0;
        inputVertical = 0;
        timerBeam = 0;
    }

    private void FixedUpdate() {
        bool isGrounded = false;
        ContactPoint2D[] contacts;

        foreach ( Collision2D coll in _groundCollisions )
        {
            contacts = coll.contacts;

            if (contacts.Length > 0)
            {
                foreach (ContactPoint2D c in contacts)
                {
                    if (c.normal.y >= 0.5f)
                    {
                        isGrounded = true;
                        break;
                    }
                }
            }

            if (isGrounded)
            {
                break;
            }
        }

        if (isGrounded)
        {
            _hasDoubleJumped = false;
        }

        if (manette) {
            if (Input.GetAxis("Horizontal") > 0.75)
                inputHorizontal = 1;
            else if (Input.GetAxis("Horizontal") < -0.75)
                inputHorizontal = -1;
            else inputHorizontal = 0;

            if (Input.GetAxis("Vertical") > 0.75)
                inputVertical = 1;
            else if (Input.GetAxis("Vertical") < -0.75)
                inputVertical = -1;
            else inputVertical = 0;
        } else {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
        }

        if (timerBeam == 0)
        {
            changeOrientation(inputHorizontal, inputVertical);
            if ((facingRight && inputHorizontal == -1) || (!facingRight && inputHorizontal == 1))
            {
                flip();
            }
        }
        else if (timerBeam > 0 && timerBeam < durationBeam * 50)
        {
            timerBeam++;
        }
        else if (timerBeam >= durationBeam * 50)
        {
            timerBeam = 0;
        }
        
        if (!Input.GetButton("Stop")) {
            charBody.velocity = new Vector2(inputHorizontal * maxSpeed, charBody.velocity.y);
        } else {
            charBody.velocity = Vector2.zero;
        }

        charAnimation.SetFloat("speed", Mathf.Abs(inputHorizontal));

        if (Input.GetButtonDown("Jump")) {
            if (isGrounded) {
                charBody.velocity = new Vector2(charBody.velocity.x, jumpHeight);
            } else {
                if (_hasDoubleJumped == false) {
                    _hasDoubleJumped = true;
                    charBody.velocity = new Vector2(charBody.velocity.x, 0);
                    charBody.velocity = new Vector2(charBody.velocity.x, jumpHeight * (float)0.75);
                }
            }

        }

        if (((!manette && Input.GetAxis("Fire1") > 0) || (manette && Input.GetAxis("Trigger") > 0.5)) && HasGunShieldBreaker) {
            fireBullet();
        }

        if (((!manette && Input.GetAxis("Fire2") > 0) || (manette && Input.GetAxis("Trigger") < -0.5)) && HasGunBeam) {
            nextFireBullet = Time.time + durationBeam;
            fireBeam();
        }
    }

    void changeOrientation(float inputHorizontal, float inputVertical)
    {
        Transform child = transform.GetChild(0);
        if (inputHorizontal == 1 && inputVertical == 1)
        {
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

    void fireBullet() {
        if (Time.time > nextFireBullet) {
            nextFireBullet = Time.time + fireRateBullet;
            Instantiate(bullet, gunTip.position, pivotGunTip.rotation);
        }
    }

    void fireBeam() {
        if (Time.time > nextFireBeam) {
            timerBeam++;
            nextFireBeam = Time.time + fireRateBeam;
            GameObject childBeam = Instantiate(beam, gunTip.position, gunTip.rotation) as GameObject;
            childBeam.transform.parent = gunTip;
            childBeam.gameObject.GetComponent<DestroyMe>().aliveTime = durationBeam;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            _groundCollisions.Add(coll);
        }

        if (coll.gameObject.tag == "GunShieldBreaker")
        {
            HasGunShieldBreaker = true;
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "GunBeam")
        {
            HasGunBeam = true;
            Destroy(coll.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            foreach (Collision2D c in _groundCollisions)
            {
                if (c.gameObject == coll.gameObject)
                {
                    _groundCollisions.Remove(c);
                    _groundCollisions.Add(coll);
                    break;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            foreach ( Collision2D c in _groundCollisions )
            {
                if (c.gameObject == coll.gameObject)
                {
                    _groundCollisions.Remove(c);
                    break;
                }
            }
        }
    }
}
