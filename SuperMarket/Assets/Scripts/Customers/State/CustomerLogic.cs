using System.Collections.Generic;
using UnityEngine.AI;

public class CustomerLogic : IBotLogic, IBehaviorSwitcher
{
    private readonly List<IBehavior> _behaviors;
    private IBehavior _currentBehavior;

    public CustomerLogic(NavMeshAgent navAgent, Basket basket, List<Shop> shops, Shop checkoutShop){
        var behaviorActions = new BehaviorActions(navAgent, basket, shops, checkoutShop);
        _behaviors = new List<IBehavior>()
        {
            new CustomerMainBehavior(this, behaviorActions),
            new ComeToRandomShopBehavior(this, behaviorActions),
            new GetProductsBehavior(this, behaviorActions),
            new CheckOutBehavior(this, behaviorActions)
        };
    }

    public void Play(){
        SwitchBehavior<CustomerMainBehavior>();
    }

    public void Update(){
        _currentBehavior.Update();
    }

    public void SwitchBehavior<T>() where T : IBehavior{
        var behavior = _behaviors.FindLast(behavior => behavior is T);
        if (behavior == null) return;
        _currentBehavior?.Exit();
        _currentBehavior = behavior;
        _currentBehavior.Enter();
    }
}
