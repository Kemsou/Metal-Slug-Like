using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    
    [SerializeField]
    protected bool berserk = false;

    private float currentShield;

    [SerializeField]
    protected float maxShield;
    [SerializeField]
    protected GameObject enemyShieldEF;
    [SerializeField]
    protected Slider enemyShieldSlider;
    [SerializeField]
    GameObject _gfxObject = null;

    protected Rigidbody2D enemyBody;
    protected Animator enemyAnimator;

    protected bool facingRight = true;
    protected float facingTime = 5f;
    protected float nextFlip = 0f;
    protected bool canFlip = true;

    public bool isBerserk {
        get {
            return berserk;
        }
    }

    public float CurrentShield {
        get {
            return currentShield;
        }

        set {
            currentShield = value;
        }
    }

    private void Awake() {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyAnimator = _gfxObject.GetComponentInChildren<Animator>();
    }

    // Use this for initialization
    void Start() {
        CurrentShield = maxShield;
        enemyShieldSlider.maxValue = maxShield;
        enemyShieldSlider.value = maxShield;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextFlip) {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }

    protected void flip() {
        if (!canFlip) {
            return;
        }
        facingRight = !facingRight;
        Vector3 scale = _gfxObject.transform.localScale;
        scale.x = scale.x * (-1);
        _gfxObject.transform.localScale = scale;
    }

    public void addDamage(float damage) {
        if (CurrentShield > 0) {
            CurrentShield = CurrentShield - damage;
            if (CurrentShield <= 0) {
                CurrentShield = 0;
                makeBerserk();
            }
            enemyShieldSlider.value = CurrentShield;
        }
    }

    protected void makeBerserk() {
        berserk = true;
        enemyShieldSlider.gameObject.SetActive(false);
    }

    public void makeDead() {
        Destroy(gameObject);
        Instantiate(enemyShieldEF, transform.position, transform.rotation);
    }
}
