using Cysharp.Threading.Tasks;
using UnityEngine;

public class ProductFactory : MonoBehaviour
{
    private const int POOL_SIZE = 5;

    [SerializeField] private Product prefab;
    [SerializeField] protected int produceTime;
    [SerializeField] protected Shop resultShop;

    private PoolObjects<Product> _pool;
    protected bool InProcess;

    protected virtual void Start(){
        _pool = new PoolObjects<Product>(prefab, POOL_SIZE, true, transform);

        resultShop.StoreDefinitePositionView.PutEvent += TryProduce;
        resultShop.StoreDefinitePositionView.GetEvent += TryProduce;

        TryProduce();
    }

    protected virtual void OnDestroy(){
        resultShop.StoreDefinitePositionView.PutEvent -= TryProduce;
        resultShop.StoreDefinitePositionView.GetEvent -= TryProduce;
    }

    protected virtual void TryProduce(){
        if (InProcess || resultShop.StoreDefinitePositionView.OutOfSpace) return;
        Produce();
    }

    protected async void Produce(){
        InProcess = true;
        await UniTask.Delay(produceTime);
        InProcess = false;
        var product = _pool.GetFreeElement();
        resultShop.StoreDefinitePositionView.Put(product);

    }
}