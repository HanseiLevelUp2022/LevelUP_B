using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public float attackDelay;

    protected override void Awake()
    {
        base.Awake();

        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        float oldtime = 0;

        WaitForSeconds waitForSeconds = new WaitForSeconds(attackDelay);

        while (true)
        {
            if (oldtime + attackDelay < Time.time)
            {
                var bullet = bulletPool.Get();

                bullet.Set(
                    startPos: transform.position,
                    angle: -90,
                    speed: 0.1f,
                    damage: 30,
                    time: 3
                    );
                
                oldtime = Time.time;
            }
            yield return null;
        }
    }
}
