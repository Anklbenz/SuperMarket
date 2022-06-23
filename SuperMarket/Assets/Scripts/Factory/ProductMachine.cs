using System.Linq;
using UnityEngine;

public class ProductMachine : ProductFactory
{
    [SerializeField] private Shop[] partStores;
    private bool PartsAvailable => partStores.All(store => store.Store.Count != 0);

    protected override void Start(){
        base.Start();

        foreach (var store in partStores)
            store.Store.PutEvent += TryProduce;
    }

    protected override void OnDestroy(){
        base.OnDestroy();

        foreach (var store in partStores)
            store.Store.PutEvent -= TryProduce;
    }

    private void GetParts(){
        foreach (var store in partStores){
            var product = store.Store.Get();
            product.gameObject.SetActive(false);
        }
    }

    protected override void TryProduce(){
        if (InProcess || resultShop.Store.OutOfSpace || !PartsAvailable) return;
        GetParts();
        Produce();
    }
}