using UniRx;
using UnityEngine;

namespace Unit3
{
    public class ObjectCreator:MonoBehaviour
    {
        [SerializeField] private ResourcesProvider _resourcesProvider;

        private void Start()
        {
            _resourcesProvider.Setup();
            _resourcesProvider.PrefabAsyncObservable.Subscribe(CreateObject).AddTo(gameObject);
        }

        private void CreateObject(GameObject prefab)
        {
            Instantiate(prefab);
            _resourcesProvider.Cleanup();
        }
    }
}