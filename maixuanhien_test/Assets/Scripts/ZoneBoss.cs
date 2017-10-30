using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBoss : MonoBehaviour {

    [SerializeField]
    private GameObject headthSlider;
    [SerializeField]
    private GameObject boss;

	// Use this for initialization
	void Start () {
        headthSlider.SetActive(true);
        boss.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
