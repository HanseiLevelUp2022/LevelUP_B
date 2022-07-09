using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class Bullet : MonoBehaviour
    {
        public UnityEngine.Pool.ObjectPool<Bullet> bulletPool;
        private Statistic statistic;

        private new Rigidbody2D rigidbody;

        private static WaitForSeconds delay = new(5);

        public void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Set(Vector2 startPos, Vector2 force, Statistic statistic)
        {
            this.statistic = statistic;

            float rad = Mathf.Atan2(force.normalized.y, force.normalized.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(rad, Vector3.forward);

            transform.position = startPos;

            rigidbody.AddForce(
                force: force, 
                mode: ForceMode2D.Impulse
                );

            StartCoroutine(Release());

            IEnumerator Release()
            {
                yield return delay;
                this.Release();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Entity entity))
            {
                entity.TakeDamage(statistic);
            }
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Entity entity))
            {
                entity.TakeDamage(statistic);
            }
        }



        private void Release()
        {
            bulletPool.Release(this);
        }
    }
}