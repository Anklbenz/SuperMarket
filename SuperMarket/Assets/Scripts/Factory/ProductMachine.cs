using System.Linq;
using UnityEngine;

public class ProductMachine : ProductFactory
{
    [SerializeField] private Shop[] partShops;
    private bool PartsAvailable => partShops.All(shop => shop.Store.Count != 0);

    protected override void Start(){
        base.Start();

        foreach (var shop in partShops)
            shop.Store.PutEvent += TryProduce;
    }

    protected override void OnDestroy(){
        base.OnDestroy();

        foreach (var shop in partShops)
            shop.Store.PutEvent -= TryProduce;
    }

    private void GetParts(){
        foreach (var shop in partShops){
            var product = shop.Store.Get();
            product.gameObject.SetActive(false);
        }
    }

    protected override void TryProduce(){
        if (InProcess || !resultShop.Store.HasFreeSpace || !PartsAvailable) return;
        GetParts();
        Produce();
    }
}