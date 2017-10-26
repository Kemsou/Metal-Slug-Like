using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDegat : MonoBehaviour {

    [SerializeField]
    private float damage;
    private float damageRate = 0.5f;
    private float nextDamage;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.addDamage(damage);
            nextDamage = damageRate + Time.time;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy") && nextDamage < Time.time)
        {
            
            EnemyKamikazeBehavior kamikaze = collision.gameObject.transform.parent.GetComponent<EnemyKamikazeBehavior>();
            kamikaze.addDamage(damage);
            nextDamage = damageRate + Time.time;
            if (kamikaze.CurrentShield <= 0)
            {
                kamikaze.makeDead();
            }
        }
    }
    
}
