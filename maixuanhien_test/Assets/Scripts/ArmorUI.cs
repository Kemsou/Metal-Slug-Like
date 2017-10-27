using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUI : MonoBehaviour {

    public GameObject character;
    [SerializeField]
    private GameObject armorUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void UpdateAmorUI()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Vector3 position = new Vector3(transform.position.x + 40, transform.position.y - 40, transform.position.z);
        for (int life = 0; life < character.GetComponent<PlayerHealth>().currentHealth - 1; life++)
        {
            GameObject armor = Instantiate(armorUI);
            armor.transform.SetParent(this.gameObject.transform);
            armor.transform.position = position;
            position.x += 40;
        }
    }
}
