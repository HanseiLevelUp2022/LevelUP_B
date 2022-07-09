using UnityEngine;

namespace ShootingGame
{
    [System.Serializable]
    public class Statistic
    {
        public Statistic()
        {

        }

        public Statistic(
            float attackDamage,
            float attackDelay,
            float attackSpeed,
            float moveSpeed,
            float penetrationRate
            )
        {
            AttackDamage = attackDamage;
            AttackDelay = attackDelay;
            AttackSpeed = attackSpeed;
            MoveSpeed = moveSpeed;
            PenetrationRate = penetrationRate;
        }
        [SerializeField]
        private float attackDamage;
        [SerializeField]
        private float attackDelay;
        [SerializeField]
        private float attackSpeed;
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float penetrationRate;//public float markOfLethality

        public float AttackDamage
        {
            get
            {
                return attackDamage;
            }
            set
            {
                attackDamage = value;
            }
        }

        public float AttackDelay
        {
            get
            {
                return this.attackDelay;
            }
            set
            {
                this.attackDelay = value;
            }
        }

        public float AttackSpeed
        {
            get
            {
                return attackSpeed;
            }
            set
            {
                attackSpeed = value;
            }
        }

        public float MoveSpeed
        {
            get
            {
                return moveSpeed;
            }
            set
            {
                moveSpeed = value;
            }
        }

        public float PenetrationRate
        {
            get
            {
                return 1 - penetrationRate;
            }
            set
            {
                penetrationRate = value;
            }
        }

        //public DamageInfo(float damage, float penetrationRate)
        //{
        //    this.damage = damage;
        //    this.penetrationRate = penetrationRate < 0 ? 0
        //        : penetrationRate > 1 ? 1
        //        : 0;
        //}

        public static Statistic operator +(Statistic a, Statistic b)
        {
            return new Statistic(
                attackDamage: a.AttackDamage + b.AttackDamage,
                attackDelay: a.AttackDelay + b.AttackDelay,
                attackSpeed: a.AttackSpeed + b.AttackSpeed,
                moveSpeed: a.MoveSpeed + b.MoveSpeed,
                penetrationRate: a.PenetrationRate + b.PenetrationRate
                );
        }
    }
}