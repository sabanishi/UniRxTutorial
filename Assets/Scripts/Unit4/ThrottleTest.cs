using System;
using UniRx;
using UnityEngine;

namespace Unit4
{
    public class ThrottleTest:MonoBehaviour
    {
        private void Awake()
        {
            transform.ObserveEveryValueChanged(x => x.position)
                .Throttle(TimeSpan.FromSeconds(1)).Subscribe(x => Debug.Log(x)).AddTo(gameObject);
        }
    }
}