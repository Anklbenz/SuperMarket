using Enums;
using UnityEngine;

public class PutShop : Shop, IPut
{
    [SerializeField] protected ProductType storeType;
    public ProductType Type => storeType;
    public bool CanPut => StoreDefinitePositionView.CanPut;

    public void Put(Product product){
        StoreDefinitePositionView.Put(product);
    }
}
