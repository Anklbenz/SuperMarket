using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreVisualizer
{
    private int LastItemIndex => _store.Count - 1;
    private readonly Store _store;
    private readonly Transform _productsParent;
    private readonly Transform[] _productsPositions;
    private readonly Stack<Product> _products;

    public StoreVisualizer(Store store,  Stack<Product> products, Transform productParent,Transform[] productsPositions){
        _store = store;
        _products = products;
        _productsParent = productParent;
        _productsPositions = productsPositions;

        _store.ProductPushedEvent += ProductArrange;
    }

    private void ProductArrange(){
        var productTransform = _products.Peek().transform;
        productTransform.parent = _productsParent;
        productTransform.position = _productsPositions[LastItemIndex].position;
    }
}
