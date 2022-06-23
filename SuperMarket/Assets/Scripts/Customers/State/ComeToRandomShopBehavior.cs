using UnityEngine;

public class ComeToRandomShopBehavior : IBehavior
{
    private readonly BehaviorActions _behaviorActions;
    private readonly IBehaviorSwitcher _behaviorSwitcher;
    private bool _isMoving;

    public ComeToRandomShopBehavior(IBehaviorSwitcher behaviorSwitcher, BehaviorActions behaviorActions){
        _behaviorSwitcher = behaviorSwitcher;
        _behaviorActions = behaviorActions;
    }

    public void Enter(){
        _behaviorActions.RequiredQuantity = Random.Range(1, _behaviorActions.BasketFreeSpace);
        _behaviorActions.ChosenShop = _behaviorActions.GetRandomStore();
        _behaviorActions.MoveTo(_behaviorActions.ChosenShop.PickPoint);
        _isMoving = true;
    }

    public void Update(){
        if (!_isMoving) return;
        if (_behaviorActions.OnDestination){
           _behaviorSwitcher.SwitchBehavior<GetProductsBehavior>();
        }
    }
    public void Exit(){ }
}