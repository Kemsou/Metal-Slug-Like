using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private bool triggered;

	// Use this for initialization
	void Start () {
        triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject SpawnPlayer(GameObject character)
    {
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        GameObject player = Instantiate(character);
        player.transform.position = this.transform.position;
        
        if (camera != null)
        {
            camera.GetComponent<cameraFollow>().target = player.transform;
        }

        GameObject.Find("playerHUDCanvas/playerArmorUI").GetComponent<ArmorUI>().character = player;
        GameObject.Find("playerHUDCanvas/playerArmorUI").GetComponent<ArmorUI>().UpdateAmorUI();

        if (this.gameObject.GetComponent<SpawnerPlayer>() != null)
        {
            player.GetComponent<PlayerController>().HasGunBeam = false;
            player.GetComponent<PlayerController>().HasGunShieldBreaker = false;
        }
        else
        {
            player.GetComponent<PlayerController>().HasGunBeam = true;
            player.GetComponent<PlayerController>().HasGunShieldBreaker = true;
        }

        return player;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && triggered == false)
        {
            triggered = true;
            gameObject.transform.parent.GetComponent<SpawnerPlayer>().ChangeCheckpoint(this.transform);
        }
    }
}
