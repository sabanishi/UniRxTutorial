using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Unit4
{
    public class FilterTest : MonoBehaviour
    {
        public class MyObject
        {
            private readonly int _value;
            public int Value => _value;

            public MyObject(int val)
            {
                _value = val;
            }
        }

        private void Start()
        {
            //Where
            //Observable.Range(0, 10).Where(x => x % 2 == 0).Subscribe(x => Debug.Log(x)).AddTo(gameObject);

            //Where2
            /*Observable.Range(0, 10).Where((x, counter) => (10 - x) > counter).Subscribe(x => Debug.Log(x))
                .AddTo(gameObject);*/

            //OfType
            /*object[] objects = {0,"1",1.0f,"1.0f","Hoge" };

            objects.ToObservable().OfType<object, int>().Subscribe(x => Debug.Log(x + 1));*/

            //Distinct1
            //var array = new[] { new MyObject(1), new MyObject(2), new MyObject(1), new MyObject(3), new MyObject(2) };
            //Distinct1
            /*array.ToObservable().Distinct().Subscribe(x=>Debug.Log(x.Value));
            Debug.Log("--------------------");
            //Distinct2
            array.ToObservable().Distinct(x=>x.Value).Subscribe(x=>Debug.Log(x.Value));
            Debug.Log("--------------------");*/
            //Distinct3 and IEqualityComparer
            /*var key = new Keys(2, 2);
            var dict = new Dictionary<Keys, string>(new KeyEqualityComparer())
            {
                { new Keys(1, 1), "A" },
                { new Keys(1, 2), "B" },
                { new Keys(2, 1), "C" },
                { new Keys(2, 2), "D" },
            };
            Debug.Log(dict.TryGetValue(key, out var val) ? $"Contains:{val}" : "Not Contains");
            Debug.Log("--------------------");
            var dict2 = new Dictionary<Keys, string>()
            {
                { new Keys(1, 1), "A" },
                { new Keys(1, 2), "B" },
                { new Keys(2, 1), "C" },
                { new Keys(2, 2), "D" },
            };
            Debug.Log(dict2.TryGetValue(key, out var val2) ? $"Contains:{val2}" : "Not Contains");
            Debug.Log("--------------------");
            var key1 = new Keys(1, 1);
            var key2 = new Keys(1, 2);
            var key3 = new Keys(2, 1);
            var key4 = new Keys(2, 2);
            var keysArray=new []{key1,key2,key3,key4,key,key1};
            keysArray.ToObservable().Distinct(new KeyEqualityComparer()).Subscribe(x=>Debug.Log(x.ToString()));
            Debug.Log("--------------------");
            keysArray.ToObservable().Distinct().Subscribe(x=>Debug.Log(x.ToString()));*/
            
            //Last
            var array = new[] { 1, 2, 3,4,5,6,7,8,9,10};
            //array.ToObservable().Last(x => x%2 !=0).Subscribe(x=>Debug.Log(x));
            
            //Skip
            //array.ToObservable().Skip(2).Subscribe(x => Debug.Log(x)).AddTo(gameObject);
            
            //SkipUntil
            /*array.ToObservable().SkipWhile((x, counter) => (x + counter) < 10)
                .Subscribe(x => Debug.Log(x));*/
            
            //TakeUntil
            /*Observable.Interval(TimeSpan.FromSeconds(1.0f))
                .TakeUntil(this.OnDestroyAsObservable())
                .Subscribe(x => Debug.Log(x));*/
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }
        }

        public class Keys
        {
            public int Key1 {get;}
            public int Key2 {get;}
            public Keys(int key1,int key2)=>(Key1,Key2)=(key1,key2);

            public override string ToString()
            {
                return $"Key1:{Key1}, Key2:{Key2}";
            }
        }

        public class KeyEqualityComparer : IEqualityComparer<Keys>
        {
            public bool Equals(Keys a, Keys b)
            {
                return (a.Key1, a.Key2) == (b.Key1, b.Key2);
            }

            public int GetHashCode(Keys obj)
            {
                return (obj.Key1,obj.Key2).GetHashCode();
            }
        }
    }
}