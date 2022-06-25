using UnityEngine;

public class ComeToRandomShopBehavior : IBehavior, IUpdateable
{
    private readonly Bot _bot;
    private readonly IBehaviorSwitcher _behaviorSwitcher;
    private bool _isMoving;

    public ComeToRandomShopBehavior(IBehaviorSwitcher behaviorSwitcher, Bot bot){
        _behaviorSwitcher = behaviorSwitcher;
        _bot = bot;
    }

    public void Enter(){
        _bot.RequiredQuantity = Random.Range(1, _bot.FreeSpaceAmount);
        _bot.putShop = _bot.GetRandomStore();
        _bot.MoveTo(_bot.putShop.PickPoint);
        _isMoving = true;
    }

    public void Update(){
        if (!_isMoving) return;
        if (_bot.OnDestination){
           _behaviorSwitcher.SwitchBehavior<GetProductsBehavior>();
        }
    }
    
    public void Exit(){ }
}