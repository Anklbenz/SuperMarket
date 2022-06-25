public class GetProductsBehavior : IBehavior
{
    private readonly Bot _bot;
    private readonly IBehaviorSwitcher _behaviorSwitcher;

    public GetProductsBehavior(IBehaviorSwitcher behaviorSwitcher, Bot bot){
        _behaviorSwitcher = behaviorSwitcher;
        _bot = bot;
    }

    public void Enter(){
        GetProducts();
    }
    
    public void Exit(){
     //   _bot.putShopWithFixedPositions.StoreWithFixedPositions.PutEvent -= GetProducts;
    }

    private void GetProducts(){
        while (_bot.RequiredQuantity > 0){
            if (_bot.GetProduct()){
                _bot.RequiredQuantity--;
            }
            else{
              //  _bot.putShopWithFixedPositions.StoreWithFixedPositions.PutEvent += GetProducts;
                return;
            }
        }
        _behaviorSwitcher.SwitchBehavior<CustomerMainBehavior>();
    }
}


