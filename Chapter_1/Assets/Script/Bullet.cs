using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEntity;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float time;

    private void Start()
    {
        Destroy(this.gameObject, time);
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
}
