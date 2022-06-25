using System;
using System.Linq;
using UnityEngine;

public class GridViewer : IDisposable
{
    private readonly Transform _parentContainer;
    private readonly Vector3 _offsetVector;
    private readonly Store _store;
    private readonly int _width, _height;

    public GridViewer(Store store, Transform parentContainer, Vector3 offsetVector, int width, int height){
        _store = store;
        _parentContainer = parentContainer;
        _offsetVector = offsetVector;
        _height = height;
        _width = width;

        _store.PutEvent += PutInOrder;
    }

    public virtual void Dispose() => _store.PutEvent -= PutInOrder;

    private void PutInOrder(){
        var productTransform = _store.Items.Last().transform;
        productTransform.parent = _parentContainer;

        var itemPosition = IndexToVector3PositionWithOffset(_store.Items.Count - 1);
        productTransform.localPosition = itemPosition;
    }

    public Vector3 IndexToVector3PositionWithOffset(int indexInList){
        // Calculation taken heuristic way
        var x = indexInList % _width;
        var y = indexInList / (_width * _height);
        var z = indexInList / _width - y * 2;

        var xWithOffset = x * _offsetVector.x;
        var yWithOffset = y * _offsetVector.y;
        var zWithOffset = z * _offsetVector.z;

        return new Vector3(xWithOffset, yWithOffset, zWithOffset);
    }
}