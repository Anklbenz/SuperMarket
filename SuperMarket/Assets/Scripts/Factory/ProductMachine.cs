using System.Linq;
using UnityEngine;

public class ProductMachine : ProductFactory
{
    [SerializeField] private Shop[] partStores;
    private bool PartsAvailable => partStores.All(store => store.StoreDefinitePositionView.Count != 0);

    protected override void Start(){
        base.Start();

        foreach (var store in partStores)
            store.StoreDefinitePositionView.PutEvent += TryProduce;
    }

    protected override void OnDestroy(){
        base.OnDestroy();

        foreach (var store in partStores)
            store.StoreDefinitePositionView.PutEvent -= TryProduce;
    }

    private void GetParts(){
        foreach (var store in partStores){
            var product = store.StoreDefinitePositionView.Get();
            product.gameObject.SetActive(false);
        }
    }

    protected override void TryProduce(){
        if (InProcess || resultShop.StoreDefinitePositionView.OutOfSpace || !PartsAvailable) return;
        GetParts();
        Produce();
    }
}