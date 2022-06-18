using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy1 : Enemy
{
    public float attackDelay;
    public float speed;

    public ObjectPool<Enemy> objectPool;

    protected override void Awake()
    {
        base.Awake();

        StartCoroutine(Attack());
    }

    private void FixedUpdate()
    {
        rigidbody.transform.position += speed * Vector3.down;

        if (rigidbody.transform.position.y < -7)
        {
            Release();
        }
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

    private void Release()
    {
        objectPool.Release(this);
    }
}
