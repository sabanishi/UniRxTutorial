using System;
using UniRx;
using UnityEngine;

namespace Unit3
{
    public class UnityEventTest:MonoBehaviour
    {
        private IDisposable _disposable;
        private int _money;

        private void Start()
        {
            //_disposable = Observable.EveryEndOfFrame().Subscribe(_ => Debug.Log("Update")).AddTo(gameObject);
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Observable.NextFrame(FrameCountType.Update).Subscribe(_ => Debug.Log("Click"));
                if (_disposable != null)
                {
                    _disposable.Dispose();
                }
            }
        }
    }
}