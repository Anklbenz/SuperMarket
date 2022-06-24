using Enums;

public class GetShop : Shop, IGet
{
    public Product Get(){
        return StoreDefinitePositionView.Count > 0 ? StoreDefinitePositionView.Get() : null;
    }
}
