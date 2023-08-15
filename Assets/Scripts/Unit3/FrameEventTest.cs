using System;
using Cysharp.Threading.Tasks;
using UniRx;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

namespace Unit3
{
    public class FrameEventTest:MonoBehaviour
    {
        public class MyEventArgs:EventArgs
        {
            public int Value { get; }

            public MyEventArgs(int value)
            {
                Value = value;
            }
        }

        private event EventHandler<MyEventArgs> _onEvent;
        private event Action<int> _callBackAction;

        [SerializeField] private Button _button;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private void Awake()
        {
            _onEvent = (sender, args) =>
            {
                Debug.Log(sender.ToString());
                Debug.Log($"{args.Value}");
            };
            
            _callBackAction = x => Debug.Log($"CallBackAction:{x}");
        }

        private void Start()
        {
            Observable.FromEvent<EventHandler<MyEventArgs>, MyEventArgs>(
                    h => (sender, e) => h(e),
                    h => _onEvent += h,
                    h => _onEvent -= h)
                .Subscribe().AddTo(gameObject);

            Observable.FromEvent<int>(
                h => _callBackAction += h,
                h => _callBackAction -= h).Subscribe(
                x=>Debug.Log($"OnNext:{x}")).AddTo(gameObject);
            
            _onEvent?.Invoke(this,new MyEventArgs(100));
            _callBackAction?.Invoke(200);

            _button.onClick.AsObservable().Subscribe(_=>Debug.Log("Click")).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}