<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomerHit : MonoBehaviour {

    [SerializeField]
    GameObject bulletBomerExplosion;
    [SerializeField]
    float damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Instantiate(bulletBomerExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.addDamage(damage);
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomerHit : MonoBehaviour {

    [SerializeField]
    GameObject bulletBomerExplosion;
    [SerializeField]
    float damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Instantiate(bulletBomerExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.addDamage(damage);
        }
    }
}
>>>>>>> 8e32229531b2e655db7149cf7efa9380102e4345
