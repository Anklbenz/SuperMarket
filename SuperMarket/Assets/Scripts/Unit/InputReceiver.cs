using System;
using UnityEngine;

public class InputReceiver
{
    public event Action<Vector3> MoveEvent;

    public void Update(){
        var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        MoveEvent?.Invoke(moveVector);
    }
}
