using System;
using UnityEngine;

public class StackViewer : GridViewer
{
    private const int GRID_WIDTH = 1;
    private const int GRID_HEIGHT = 1;
    
    private readonly Store _store;

    public StackViewer(Store store, Transform parentContainer, Vector3 offsetVector) 
        : base(store, parentContainer, offsetVector, GRID_WIDTH, GRID_HEIGHT){
        
        _store = store;
        _store.GetEvent += RecalculatePositions;
    }
    
    public override void Dispose(){
        base.Dispose();
        _store.GetEvent -= RecalculatePositions;
    }

    private void RecalculatePositions(){
        for (var i = 0; i < _store.Count; i++)
            _store.Items[i].transform.localPosition = IndexToVector3PositionWithOffset(i);
    }
}