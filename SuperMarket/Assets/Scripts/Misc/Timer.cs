using System;
using UnityEngine;

public class Timer
{
    public event Action TimerEvent;
    private float _timer;
    private bool _isTick = false;
    private float _delay;

    public Timer(float delay){
        _delay = delay;
    }

    public void Start(){
        _isTick = true;
        _timer = SetInterval();
    }

    public void Stop(){
        _isTick = false;
    }

    public void Tick(){
        if (!_isTick) return;

        if (_timer >= Time.realtimeSinceStartup) return;
        _timer = SetInterval();
        TimerEvent?.Invoke();
    }

    private float SetInterval(){
        return Time.realtimeSinceStartup + _delay;
    }
}