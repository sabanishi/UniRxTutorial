using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Unit3
{
    public class FactoryTest:MonoBehaviour
    {
        private IDisposable _createSubject;
        private void Start()
        {
            //Return
            /*Observable.Return(100).Subscribe(
                x=>Debug.Log("OnNext"+x),
                ex=>Debug.Log("OnError"+ex),
                ()=>Debug.Log("OnCompleted"));*/
            
            //Throw
             /*Observable.Throw<int>(new Exception("例外発生"),scheduler:Scheduler.MainThreadFixedUpdate).Subscribe(
                x => Debug.Log("OnNext" + x),
                ex => Debug.LogError("OnError:" + ex.Message)
            );*/
            
            //Defer
            /*var rand=Observable.Defer(() =>
            {
                var randVal = Random.value;
                return Observable.Return(randVal);
            });

            rand.Subscribe(x => Debug.Log(x));
            rand.Subscribe(x => Debug.Log("Second:" + x));*/
            
            //ToObservable,Scheduler
            /*var list = new List<int> { 1, 2, 3, 4, 5 };
            list.ToObservable(scheduler:Scheduler.MainThread).Subscribe(
                x=>Debug.Log($"OnNext:{x} FrameCount:{Time.frameCount}"),
                ex=>Debug.LogError("OnError"),
                ()=>Debug.Log("OnCompleted"));*/
            
            //Create
            /*var createObserver =Observable.Create<int>(observer =>
            {
                var disposable = new CancellationDisposable();

                UniTask.Void(async (CancellationToken token) =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken:token);
                        observer.OnNext(i);
                    }
                    observer.OnCompleted();
                },disposable.Token);

                return disposable;
            });
            _createSubject = createObserver.Subscribe(x => Debug.Log($"OnNext:{x}"),
                ex => Debug.LogError("OnError"),
                () => Debug.Log("OnCompleted"));*/
            
            
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_createSubject != null)
                {
                    _createSubject.Dispose();
                }
            }
        }
    }
}