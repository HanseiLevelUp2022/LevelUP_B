using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEntity
{
    public class Entity : MonoBehaviour
    {
        public float maxHP;
        [SerializeField]
        private float _HP;

        public float HP
        {
            get
            {
                return _HP;
            }
            set
            {
                _HP = value < 0 ? 0
                    : value > maxHP ? maxHP
                    : value;

                //if (value < 0)
                //{
                //    _HP = 0;
                //}
                //else if (value > maxHP)
                //{
                //    _HP = maxHP;
                //}
                //else
                //{
                //    _HP = value;
                //}
            }
        }

        public new Rigidbody2D rigidbody;

        protected virtual void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();

        }
    }
}
