using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefinitePositionViewer
{
    private readonly StoreDefinitePositionView _storeDefinitePositionView;
    private readonly Transform _productsParent;
    private readonly Transform[] _productsPositions;

    public DefinitePositionViewer(StoreDefinitePositionView storeDefinitePositionView, Transform productParent, Transform[] productsPositions){
        _storeDefinitePositionView = storeDefinitePositionView;
        _productsParent = productParent;
        _productsPositions = productsPositions;

        _storeDefinitePositionView.PutEvent += PuiInOrder;
    }

    private void PuiInOrder(){
        var productTransform = _storeDefinitePositionView.Items.Last().transform;
        productTransform.parent = _productsParent;
        productTransform.position = _productsPositions[_storeDefinitePositionView.Items.Count - 1].position;
    }
}
