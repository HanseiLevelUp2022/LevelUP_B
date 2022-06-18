using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEntity;
using UnityEngine.Pool;

public class Player : Entity
{
    public float speed;

    [SerializeField]
    private GameObject bullet;

    private ObjectPool<Bullet> bulletPool;

    protected override void Awake()
    {
        base.Awake();

        bullet = Resources.Load<GameObject>("Prefab/BulletPrefab");
    }

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(
            createFunc: () =>
            {
                var bullet = Instantiate(
                original: this.bullet,
                position: transform.position,
                rotation: new Quaternion()
                );

                bullet.GetComponent<Bullet>().bulletPool = bulletPool;

                return bullet.GetComponent<Bullet>();
            },
            actionOnGet: (bullet) =>
            {
                bullet.gameObject.SetActive(true);

                bullet.GetComponent<Bullet>().Set(
                    startPos: transform.position,
                    angle: 90,
                    speed: 0.1f,
                    damage: 30,
                    time: 3
                    );
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
            maxSize: 20
            );
    }

    private void Update()
    {
        // 1 ¿ÞÂÊ, 2 ¿À¸¥ÂÊ, 3 ÈÙ
        if (Input.GetMouseButton(0))
        {
            bulletPool.Get();
        }
    }

    private void FixedUpdate()
    {
        // GetAxis = 0, 0.1 0.2 0.3 ...
        // GEtAxisRaw = 0, 1
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rigidbody.transform.position += new Vector3(horizontal, vertical, 0).normalized * speed;
    }
}