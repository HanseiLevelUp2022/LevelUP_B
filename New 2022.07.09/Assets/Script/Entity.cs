using UnityEngine;

namespace ShootingGame
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private float health;
        protected virtual float Health
        {
            get
            {
                return health;
            }
            set
            {
                Debug.Log(value);
                health = value;
            }
        }
        [SerializeField]
        protected float maxHealth;

        [SerializeField]
        private float defensive;
        protected virtual float Defensive
        {
            get
            {
                return defensive;
            }
            set
            {
                defensive = value;
            }
        }

        protected virtual void Start()
        {
            Health = maxHealth;
        }

        public void TakeDamage(Statistic info)
        {
            // ���� ������ = ������ - (���� * ����)
            float calDamage = info.AttackDamage - (Defensive * info.PenetrationRate);
            // ���ο� ü�� = ���� ü�� - (���� ������ > 0)
            float newHealth = health - (calDamage > 0 ? calDamage : 1);

            // ���� ü�� = ���ο� ä�� > 0
            Health = newHealth > 0 ? newHealth : 0;
        }
    }
}