using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public struct DamageInfo
    {
        public float damage;
        public float penetrationRate;

        public DamageInfo(float damage, float penetrationRate)
        {
            this.damage = damage;
            this.penetrationRate = penetrationRate < 0 ? 0
                : penetrationRate > 1 ? 1
                : 0;
        }
    }

    //public class DamageInfoBuilder
    //{
    //    private float damage;
    //    private float penetration;

    //    public DamageInfoBuilder()
    //    {
    //        damage = 0;
    //        damage = penetration;
    //    }

    //    public DamageInfoBuilder SetDamage(float damage)
    //    {
    //        this.damage = damage;

    //        return this;
    //    }

    //    public DamageInfoBuilder setPenetration(float penetration)
    //    {
    //        this.penetration = penetration;

    //        return this;
    //    }

    //    public Build()
    //    {
    //        return new DamageInfo()
    //    }
    //}
}
