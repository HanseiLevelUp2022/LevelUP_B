using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEntity;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float time;

    public ObjectPool<Bullet> bulletPool;

    private void Start()
    {

    }

    public void Set(Vector2 startPos, float speed, float damage)
    {
        transform.position = startPos;
        this.speed = speed;
        this.damage = damage;

        Invoke("Release", time);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            entity.HP -= damage;
        }
    }

    private void Release()
    {
        bulletPool.Release(this);
    }
}
