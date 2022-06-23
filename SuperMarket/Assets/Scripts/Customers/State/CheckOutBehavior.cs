using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutBehavior : IBehavior
{

    private readonly BehaviorActions _behaviorActions;
    private readonly IBehaviorSwitcher _behaviorSwitcher;
    private bool _isMoving;

    public CheckOutBehavior(IBehaviorSwitcher behaviorSwitcher, BehaviorActions behaviorActions){
        _behaviorSwitcher = behaviorSwitcher;
        _behaviorActions = behaviorActions;
    }

    public void Enter(){
        _behaviorActions.MoveTo(_behaviorActions.CheckoutShop.PickPoint);
        _isMoving = true;
    }

    public void Update(){
        if (!_isMoving) return;
        if (_behaviorActions.OnDestination){
            Debug.Log("On Check");
           // _behaviorSwitcher.SwitchBehavior<GetProductsBehavior>();
        }
    }

    public void Exit(){}
}
