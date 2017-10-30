using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunnerBehavior : EnemyController {
    

    // Update is called once per frame
    void Update() {
        enemyBody.velocity = new Vector2(transform.right.x * speed, enemyBody.velocity.y);
        enemyAnimator.SetBool("run", true);

        if(Camera.main.WorldToScreenPoint(transform.position).x <  0 || Camera.main.WorldToScreenPoint(transform.position).x > Camera.main.pixelWidth)
        {
            Destroy(gameObject);
        }
    }
}
