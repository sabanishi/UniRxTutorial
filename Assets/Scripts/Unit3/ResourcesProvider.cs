using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Unit3
{
    public class ResourcesProvider:MonoBehaviour
    {
        private AsyncSubject<GameObject> _prefabAsyncSubject;
        
        public IObservable<GameObject> PrefabAsyncObservable => _prefabAsyncSubject;

        public void Setup()
        {
            _prefabAsyncSubject=new AsyncSubject<GameObject>();
            
            UniTask.Void(async () =>
            {
                GameObject prefab=(GameObject)await  Resources.LoadAsync<GameObject>("TestObject");
                
                _prefabAsyncSubject.OnNext(prefab);
                _prefabAsyncSubject.OnCompleted();
            });
        }

        public void Cleanup()
        {
            _prefabAsyncSubject.Dispose();
        }
    }
}