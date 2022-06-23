using System;
using UnityEngine;

public class Mover : IDisposable
{
    private readonly CharacterController _controller;
    private readonly InputReceiver _input;
    private readonly float _speed;

    public Mover(CharacterController controller, InputReceiver input, float speed){
        _controller = controller;
        _input = input;
        _speed = speed;
        _input.MoveEvent += Move;
    }

    public void Dispose() => _input.MoveEvent -= Move;

    private void Move(Vector3 dir){
        _controller.Move(dir * Time.deltaTime * _speed);
    }
}