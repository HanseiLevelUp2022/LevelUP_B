using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class Scout : Enemy
    {
        public override void Update()
        {
            Rigidbody.AddForce(Vector2.down * GameManager.ScrollSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Entity entity))
            {
                entity.TakeDamage(Statistic);
            }
        }
    }
}