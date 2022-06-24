using Enums;
using UnityEngine;

public class GridPutShop : GridShop, IPut
{
    [SerializeField] protected ProductType storeType;
    public ProductType Type => storeType;
    public bool CanPut => StoreGridView.CanPut;

    public void Put(Product product){
        StoreGridView.Put(product);
    }
}
