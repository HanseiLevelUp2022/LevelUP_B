using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using GameEntity;

public class Enemy : Entity
{
    public GameObject bulletPrefab;

    public static ObjectPool<Bullet> bulletPool;

    protected override void Awake()
    {
        base.Awake();

        bulletPool = new ObjectPool<Bullet>(
            createFunc: () =>
            {
                var bullet = Instantiate(bulletPrefab);

                bullet.GetComponent<Bullet>().bulletPool = bulletPool;

                return bullet.GetComponent<Bullet>();
            },
            actionOnGet: (bullet) =>
            {
                bullet.gameObject.SetActive(true);
            },
            actionOnRelease: (bullet) =>
            {
                bullet.gameObject.SetActive(false);
            },
            actionOnDestroy: (bullet) =>
            {
                Destroy(bullet.gameObject);
            },
            collectionCheck: default,
            defaultCapacity: default,
            maxSize: 50
            );
    }
}