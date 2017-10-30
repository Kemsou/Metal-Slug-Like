using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBoss : MonoBehaviour {

    [SerializeField]
    private GameObject headthSlider;
    [SerializeField]
    private GameObject boss;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            headthSlider.SetActive(true);
            boss.SetActive(true);
        }
    }
}
