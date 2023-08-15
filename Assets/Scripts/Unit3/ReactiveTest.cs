using UnityEngine;
using UniRx;

namespace Unit3
{
    public class ReactiveTest:MonoBehaviour
    {
        private void Start()
        {
            var property = new ReactiveProperty<int>(100);
            
            
            property.SkipLatestValueOnSubscribe().Subscribe(
                x=>Debug.Log($"OnNext:{x}"),
                ex=>Debug.Log($"OnError:{ex}"),
                ()=>Debug.Log($"OnCompleted"));

            property.Value = 100;
            property.SetValueAndForceNotify(100);
            property.Dispose();
        }
    }
}