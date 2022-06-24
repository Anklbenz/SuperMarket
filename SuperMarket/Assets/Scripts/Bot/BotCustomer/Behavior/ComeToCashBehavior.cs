using UnityEngine;

public class ComeToCashBehavior : IBehavior, IUpdateable
{
    private readonly Bot _bot;
    private readonly IBehaviorSwitcher _behaviorSwitcher;
    private bool _isMoving;

    public ComeToCashBehavior(IBehaviorSwitcher behaviorSwitcher, Bot bot){
        _behaviorSwitcher = behaviorSwitcher;
        _bot = bot;
     }

    public void Enter(){
        _bot.MoveTo(_bot.PutShop.PickPoint);
        _isMoving = true;
    }

    public void Update(){
        if (!_isMoving) return;
        if (_bot.OnDestination){
            Debug.Log("On Check");
           // _behaviorSwitcher.SwitchBehavior<GetProductsBehavior>();
        }
    }

    public void Exit(){}
}
