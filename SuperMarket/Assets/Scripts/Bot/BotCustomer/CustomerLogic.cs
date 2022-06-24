using System.Collections.Generic;
using UnityEngine.AI;

public class CustomerLogic : IBotLogic, IBehaviorSwitcher
{
    private readonly List<IBehavior> _behaviors;
    private IBehavior _currentBehavior;
  

    public CustomerLogic(Bot bot){
      _behaviors = new List<IBehavior>()
        {
            new CustomerMainBehavior(this, bot),
            new ComeToRandomShopBehavior(this, bot),
            new GetProductsBehavior(this, bot),
            new ComeToCashBehavior(this, bot)
        };
    }

    public void Play(){
        SwitchBehavior<CustomerMainBehavior>();
    }

    public void Update(){
        if (_currentBehavior is IUpdateable updateable)
            updateable.Update();
    }

    public void SwitchBehavior<T>() where T : IBehavior{
        var behavior = _behaviors.FindLast(behavior => behavior is T);
        if (behavior == null) return;
        _currentBehavior?.Exit();
        _currentBehavior = behavior;
        _currentBehavior.Enter();
    }
}
