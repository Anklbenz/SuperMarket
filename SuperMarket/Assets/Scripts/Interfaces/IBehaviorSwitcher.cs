public interface IBehaviorSwitcher
{
    void SwitchBehavior<T>() where T : IBehavior;
}
