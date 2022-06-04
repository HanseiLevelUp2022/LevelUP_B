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

    public void Set(Vector2 startPos, float angle, float speed, float damage, float time)
    {
        transform.position = startPos;
        this.speed = speed;
        this.damage = damage;
        this.time = time;

        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

        Invoke("Release", time);
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * speed;
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
