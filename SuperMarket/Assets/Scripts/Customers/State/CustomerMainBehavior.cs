using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMainBehavior : IBehavior
{
    private readonly BehaviorActions _behaviorActions;
    private readonly IBehaviorSwitcher _behaviorSwitcher;

    public CustomerMainBehavior(IBehaviorSwitcher behaviorSwitcher, BehaviorActions behaviorActions){
        _behaviorSwitcher = behaviorSwitcher;
        _behaviorActions = behaviorActions;
    }

    public void Enter(){
        if (_behaviorActions.BasketHasFreeSpace)
            _behaviorSwitcher.SwitchBehavior<ComeToRandomShopBehavior>();
        else
            _behaviorSwitcher.SwitchBehavior<CheckOutBehavior>();
    }

    public void Exit(){ }

    public void Update(){ }
}