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
            // 계산된 데미지 = 데미지 - (방어력 * 관통)
            float calDamage = info.AttackDamage - (Defensive * info.PenetrationRate);
            // 새로운 체력 = 현재 체력 - (계산된 데미지 > 0)
            float newHealth = health - (calDamage > 0 ? calDamage : 1);

            // 현재 체력 = 새로운 채력 > 0
            Health = newHealth > 0 ? newHealth : 0;
        }
    }
}