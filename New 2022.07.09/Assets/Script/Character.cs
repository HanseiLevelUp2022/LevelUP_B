using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace ShootingGame
{
    public class Character : Entity
    {
        [SerializeField]
        private Statistic statistic;
        public virtual Statistic Statistic
        {
            get
            {
                return statistic;
            }
            set
            {
                statistic = value;
            }
        }

        //[SerializeField]
        //protected float attackDelay;
        //public float AttackDelay
        //{
        //    get
        //    {
        //        return attackDelay;
        //    }
        //    set
        //    {
        //        attackDelay = value;
        //    }
        //}
        //[SerializeField]
        //protected float attackSpeed;
        //public float AttackSpeed
        //{
        //    get
        //    {
        //        return attackDelay;
        //    }
        //    set
        //    {
        //        attackDelay = value;
        //    }
        //}
        //[SerializeField]
        //protected float moveSpeed;
        //public float MoveSpeed
        //{
        //    get
        //    {
        //        return moveSpeed;
        //    }
        //    set
        //    {
        //        attackDelay = value;
        //    }
        //}

        //protected DamageInfo damageInfo;

        private new Rigidbody2D rigidbody;
        protected Rigidbody2D Rigidbody
        {
            get
            {
                return rigidbody;
            }
        }

        protected virtual void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}
