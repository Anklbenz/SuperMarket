using System;using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FixedPositionsViewer : IDisposable
{
    private readonly Store _store;
    private readonly Transform _productsParent;
    private readonly Transform[] _productsPositions;

    public FixedPositionsViewer(Store store, Transform productParent, Transform[] productsPositions){
        _store = store;
        _productsParent = productParent;
        _productsPositions = productsPositions;

        _store.PutEvent += PutInOrder;
    }

    public void Dispose() => _store.PutEvent -= PutInOrder;

    private void PutInOrder(){
        var productTransform = _store.Items.Last().transform;
        productTransform.parent = _productsParent;
        productTransform.position = _productsPositions[_store.Items.Count - 1].position;
    }
}
