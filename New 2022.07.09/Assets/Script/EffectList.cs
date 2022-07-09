using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    //Todo: 이펙트 리스트 만들기
    public class EffectList<T> where T : Character
    {
        private DoubleValue<Statistic, float> effectList;


        public void Update(float time)
        {
            
        }

        class DoubleValue<A, B>
        {
            public A value1;
            public B value2;

            public DoubleValue(A value1, B value2)
            {
                this.value1 = value1;
                this.value2 = value2;
            }
        }
    }
}
