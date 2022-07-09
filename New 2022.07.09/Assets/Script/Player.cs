using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace ShootingGame
{
    public class Player : Character
    {
        protected GameObject bulletPrefab;
        protected IEnumerator attackCoroutine;

        private bool isAttack;
        private ObjectPool<Bullet> bulletPool;

        protected override void Awake()
        {
            base.Awake();

            bulletPool = new ObjectPool<Bullet>(
                createFunc: () =>
                {
                    var temp = Instantiate(
                        original: GameManager.BulletPrefab
                        );
                    temp.gameObject.layer = LayerMask.NameToLayer("Player");
                    temp.bulletPool = bulletPool;

                    return temp;
                },
                actionOnGet: (bullet) =>
                {
                    bullet.gameObject.SetActive(true);

                    bullet.Set(
                        startPos: transform.position,
                        force: Vector2.up * Statistic.AttackSpeed,
                        statistic: Statistic
                        );
                },
                actionOnRelease: (bullet) =>
                {
                    bullet.gameObject.SetActive(false);
                },
                actionOnDestroy: (bullet) =>
                {
                    Destroy(bullet);
                },
                collectionCheck: default,
                defaultCapacity: default,
                maxSize: 70
                );

            StartCoroutine(attackCoroutine = Attack());
        }

        protected override void Start()
        {
            base.Start();

        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                isAttack = true;
            }
            else
            {
                isAttack = false;
            }
        }

        private void FixedUpdate()
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            Rigidbody.AddForce(new Vector2(inputX, inputY).normalized * Statistic.MoveSpeed, ForceMode2D.Force);
        }


        private IEnumerator Attack()
        {
            float oldTime = 0;

            while (true)
            {
                if (isAttack && oldTime + Statistic.AttackDelay < Time.time)
                {
                    bulletPool.Get();

                    oldTime = Time.time;
                }

                yield return null;
            }
        }
    }
}