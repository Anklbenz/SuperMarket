public class GetProductsBehavior : IBehavior
{
    private readonly BehaviorActions _behaviorActions;
    private IBehaviorSwitcher _behaviorSwitcher;

    public GetProductsBehavior(IBehaviorSwitcher behaviorSwitcher, BehaviorActions behaviorActions){
        _behaviorSwitcher = behaviorSwitcher;
        _behaviorActions = behaviorActions;
    }

    public void Enter(){
        GetProducts();
    }
    
    public void Exit(){
        _behaviorActions.ChosenShop.Store.PutEvent -= GetProducts;
    }

    private void GetProducts(){
        while (_behaviorActions.RequiredQuantity > 0){
            if (_behaviorActions.GetProduct()){
                _behaviorActions.RequiredQuantity--;
            }
            else{
                _behaviorActions.ChosenShop.Store.PutEvent += GetProducts;
                return;
            }
        }
        _behaviorSwitcher.SwitchBehavior<CustomerMainBehavior>();
    }
    public void Update(){}
}


