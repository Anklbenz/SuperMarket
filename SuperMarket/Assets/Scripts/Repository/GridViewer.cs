using System.Linq;
using UnityEngine;

public class GridViewer
{
    private readonly Transform _parentContainer;
    private readonly StoreGridView _store;
    private readonly Vector3 _offsetVector;
    private readonly int _width, _height;

    public GridViewer(StoreGridView store, Transform parentContainer, Vector3 offsetVector, int width, int height){
        _store = store;
        _parentContainer = parentContainer;
        _offsetVector = offsetVector;
        _height = height;
        _width = width;

        _store.PutEvent += PutInOrder;
    }

    private void PutInOrder(){
        var productTransform = _store.Items.Last().transform;
        productTransform.parent = _parentContainer;

        var itemPosition = ListIndexToVector3(_store.Items.Count - 1);
        var itemPositionWithOffset = PositionWithOffset(itemPosition);
        productTransform.localPosition = itemPositionWithOffset;
    }

    private Vector3 ListIndexToVector3(int indexInList){
        // Calculation taken heuristic way
        var x = indexInList % _width;
        var y = indexInList / (_width * _height);
        var z = indexInList / _width - y * 2;
        
        return new Vector3(x, y, z);
    }

    private Vector3 PositionWithOffset(Vector3 vector){
        var x = vector.x * _offsetVector.x;
        var y = vector.y * _offsetVector.y;
        var z = vector.z * _offsetVector.z;
        return new Vector3(x, y, z);
    }
}