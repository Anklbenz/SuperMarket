using Enums;

public class PutShop : Shop, IPut
{
    public ProductType Type => storeType;
    public bool CanPut => Store.CanPut;

    public void Put(Product product){
        Store.Put(product);
    }
}
