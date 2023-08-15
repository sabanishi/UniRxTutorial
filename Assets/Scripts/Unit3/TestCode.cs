using UniRx;
using UnityEngine;

namespace Unit3
{
    public class TestCode:MonoBehaviour
    {
        private void Start()
        {
            var behaviorSubject = new BehaviorSubject<int>(0);
            
            behaviorSubject.OnNext(0);
            behaviorSubject.OnNext(1);

            behaviorSubject.Subscribe(
                x => Debug.Log($"OnNext:{x}"),
                ex => Debug.Log($"OnError:{ex}"),
                () => Debug.Log($"OnCompleted"));
            
            behaviorSubject.OnNext(2);
            Debug.Log($"Last Value:{behaviorSubject.Value}");
            
            behaviorSubject.OnNext(3);
            behaviorSubject.OnCompleted();
            behaviorSubject.OnNext(4);
            behaviorSubject.Dispose();
        }
    }
}