using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Unit4
{
    public class SelectManyTest:MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField]private TMP_InputField _urlInputField; 
        private void Start()
        {
            //入力値を別のObservableを生成してそのまま結合
            /*_button.OnClickAsObservable()
                .Select(_ => _urlInputField.text)
                .SelectMany(uri => FetchAsync(uri).ToObservable())
                .Subscribe(Debug.Log)
                .AddTo(gameObject);*/
            
            
        }

        private async UniTask<string> FetchAsync(string uri)
        {
            using var uwr = UnityWebRequest.Get(uri);
            await uwr.SendWebRequest();
            return uwr.downloadHandler.text;
        }
    }
}