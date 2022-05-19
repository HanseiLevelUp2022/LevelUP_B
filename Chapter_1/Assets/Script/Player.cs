using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEntity;

public class Player : Entity
{
    public float speed;

    [SerializeField]
    private GameObject bullet;

    protected override void Awake()
    {
        base.Awake();

        bullet = Resources.Load<GameObject>("Prefab/BulletPrefab");
    }

    private void Update()
    {
        // 1 ¿ÞÂÊ, 2 ¿À¸¥ÂÊ, 3 ÈÙ
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(
                original: this.bullet,
                position: transform.position,
                rotation: new Quaternion()
                );
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