using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    [Header("Laser pieces")]
    public GameObject _laserStart;
    public GameObject _laserMiddle;
    public GameObject _laserEnd;

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

        maxLaserSize = 40f;
        currentLaserSize = 0;

        layer_mask  = LayerMask.GetMask("enemy");
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


        // Raycast at the right
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, this.transform.right, currentLaserSize, layer_mask);
        if (hit.collider != null && hit.collider.transform.parent.GetComponent<EnemyController>().isBerserk)
        {
            Debug.Log(hit.collider.transform.name);

            hit.collider.transform.parent.GetComponent<EnemyController>().makeDead();
        }
    }

    private Vector2 GetLaserDirection()
    {
        return this.transform.parent.parent.parent.GetComponent<PlayerController>().facingRight ? Vector2.right : Vector2.left;
    }
}