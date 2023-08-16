using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Unit4
{
    public class RepeatTest:MonoBehaviour
    {
        private void Start()
        {
            var zKeyOnChanged = this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Z))
                .DistinctUntilChanged()
                .Skip(1);

            var zKeyLogPressStart = zKeyOnChanged
                .Throttle(TimeSpan.FromSeconds(1))
                .Where(x => x);

            var zKeyReleased = zKeyOnChanged.Where(x => !x);

            this.UpdateAsObservable()
                .SkipUntil(zKeyLogPressStart)
                .TakeUntil(zKeyReleased)
                .RepeatUntilDestroy(gameObject)
                .Subscribe(_ => Debug.Log("長押し中〜")).AddTo(gameObject);
        }
    }
}