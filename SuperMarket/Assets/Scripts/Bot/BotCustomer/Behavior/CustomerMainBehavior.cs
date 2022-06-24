public class CustomerMainBehavior : IBehavior
{
    private readonly Bot _bot;
    private readonly IBehaviorSwitcher _behaviorSwitcher;

    public CustomerMainBehavior(IBehaviorSwitcher behaviorSwitcher, Bot bot){
        _behaviorSwitcher = behaviorSwitcher;
        _bot = bot;
     }

    public void Enter(){
        if (_bot.BasketHasFreeSpace)
            _behaviorSwitcher.SwitchBehavior<ComeToRandomShopBehavior>();
        else
            _behaviorSwitcher.SwitchBehavior<ComeToCashBehavior>();
    }

    public void Exit(){ }
}