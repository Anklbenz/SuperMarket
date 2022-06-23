using UnityEngine;

public class CustomTimer
{
    private readonly float _delaySeconds;
    private float _timer;
    public CustomTimer(float delay) => _delaySeconds = delay;
    public void Start() => _timer = Time.realtimeSinceStartup + _delaySeconds;
    public bool IsDone() => _timer <= Time.realtimeSinceStartup;
}
