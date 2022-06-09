using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Machine : MonoBehaviour
{
    private const int POOL_SIZE = 5;

    [SerializeField] private Store[] partStores;
    [SerializeField] private Store resultStore;
    [SerializeField] private Product resultPrefab;
    [SerializeField] private int produceTime;
    private PoolObjects<Product> _pool;
    private bool _inProcess;

    private void Awake(){
        _pool = new PoolObjects<Product>(resultPrefab, POOL_SIZE, true, this.transform);

        foreach (var store in partStores)
            store.ProductPushedEvent += Produce;

        resultStore.ProductPopedEvent += Produce;
        resultStore.ProductPushedEvent += Produce;
    }

    private void OnDestroy(){
        foreach (var store in partStores)
            store.ProductPushedEvent -= Produce;

        resultStore.ProductPopedEvent -= Produce;
        resultStore.ProductPushedEvent -= Produce;
    }

    private bool PartsAvailable(){
        return partStores.All(store => store.Count != 0);
    }

    private void GetParts(){
        foreach (var store in partStores){
            var product = store.Give();
            product.gameObject.SetActive(false);
        }
    }

    private async void Produce(){
        if (_inProcess || resultStore.MaxCount || !PartsAvailable()) return;

        GetParts();
        _inProcess = true;
        await UniTask.Delay(produceTime);

        _inProcess = false;
        var product = _pool.GetFreeElement();
        resultStore.Take(product);
    }
}
