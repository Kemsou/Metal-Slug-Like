using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    [Header("Laser pieces")]
    public GameObject _laserStart;
    public GameObject _laserMiddle;
    public GameObject _laserEnd;
    public BoxCollider2D collider2D;

    private GameObject _start;
    private GameObject _middle;
    private GameObject _end;

    private float _startWidth;
    private float _endWidth;

    private float currentLaserSize;
    private float maxLaserSize;

    private int layer_mask;

    void Start()
    {
        Vector2 laserDirection = this.GetLaserDirection();

        _start = Instantiate(_laserStart, transform) as GameObject;
        _middle = Instantiate(_laserMiddle, transform) as GameObject;
        _end = Instantiate(_laserEnd, transform) as GameObject;

        transform.localScale = Vector3.one;
        _startWidth = _start.GetComponent<SpriteRenderer>().size.x * _start.transform.localScale.x;
        _endWidth = _end.GetComponent<SpriteRenderer>().size.x * _end.transform.localScale.x;

        maxLaserSize = 18f;
        currentLaserSize = 0;

        layer_mask  = LayerMask.GetMask("enemy");
        collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Vector2 laserDirection = this.GetLaserDirection();

        if (currentLaserSize < maxLaserSize)
        {
            currentLaserSize += Time.deltaTime * 50;
        }

        

        // Place things
        _start.transform.localPosition = Vector3.zero;

        // -- the middle is after start and, as it has a center pivot, have a size of half the laser (minus start and end)
        _middle.transform.localScale = new Vector3(currentLaserSize - _startWidth, _middle.transform.localScale.y, _middle.transform.localScale.z);
        _middle.transform.localPosition = new Vector2((currentLaserSize / 2f), 0f);

        // End?
        _end.transform.localPosition = new Vector2(currentLaserSize, 0f);

        collider2D.offset = _middle.transform.localPosition;
        collider2D.size = new Vector2(_middle.transform.localScale.x + _start.transform.localScale.x, _middle.transform.localScale.y);
    }

    private Vector2 GetLaserDirection()
    {
        return this.transform.parent.parent.parent.GetComponent<PlayerController>().facingRight ? Vector2.right : Vector2.left;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ShootTable" && coll.gameObject.layer == LayerMask.NameToLayer("enemy") && coll.transform.parent.GetComponent<EnemyController>().isBerserk)
        {
            coll.transform.parent.GetComponent<EnemyController>().makeDead();
        }
    }
}