using System;
using UniRx;
using UnityEngine;

namespace Unit4
{
    public class HotConverter:MonoBehaviour
    {
        private void Start()
        {
            var original = Observable.Interval(TimeSpan.FromSeconds(1)).TakeUntilDestroy(gameObject);

            IConnectableObservable<long> multicasted = original.Publish();

            var connectDisposable = multicasted.Connect();

            multicasted.Subscribe().AddTo(gameObject);
            multicasted.Subscribe().AddTo(gameObject);
            multicasted.Subscribe().AddTo(gameObject);
            
            connectDisposable.Dispose();
        }
    }
}