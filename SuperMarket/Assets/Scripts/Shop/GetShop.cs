using Enums;

public class GetShop : Shop, IGet
{
    public Product Get(){
        return Store.Count > 0 ? Store.Get() : null;
    }
}
