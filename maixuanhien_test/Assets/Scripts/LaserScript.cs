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

    void Start()
    {
        Vector2 laserDirection = this.GetLaserDirection();

        _start = Instantiate(_laserStart, transform) as GameObject;
        _middle = Instantiate(_laserMiddle, transform) as GameObject;
        _end = Instantiate(_laserEnd, transform) as GameObject;

        transform.localScale = Vector3.one;
    }

    void Update()
    {
        Vector2 laserDirection = this.GetLaserDirection();

        // Define an "infinite" size, not too big but enough to go off screen
        float maxLaserSize = 20f;
        float currentLaserSize = maxLaserSize;

        // Raycast at the right as our sprite has been design for that
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, this.transform.right, maxLaserSize);
        bool isCollidingAnything = hit.collider != null;
        _end.SetActive(isCollidingAnything);
        
        if (isCollidingAnything)
        {
            currentLaserSize = Vector2.Distance(hit.point, this.transform.position);
        }

        // Place things

        _start.transform.localPosition = Vector3.zero;

        // -- Gather some data
        float startSpriteWidth = _start.GetComponent<Renderer>().bounds.size.x;
        float endSpriteWidth = _end.GetComponent<Renderer>().bounds.size.x;

        // -- the middle is after start and, as it has a center pivot, have a size of half the laser (minus start and end)
        _middle.transform.localScale = new Vector3(currentLaserSize - startSpriteWidth, _middle.transform.localScale.y, _middle.transform.localScale.z);
        _middle.transform.localPosition = new Vector2((currentLaserSize / 2f), 0f);

        // End?
        _end.transform.localPosition = new Vector2(currentLaserSize, 0f);
    }

    private Vector2 GetLaserDirection()
    {
        return this.transform.parent.parent.parent.GetComponent<PlayerController>().facingRight ? Vector2.right : Vector2.left;
    }
}