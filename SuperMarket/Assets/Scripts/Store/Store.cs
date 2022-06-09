using System;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Store : MonoBehaviour
{
    public event Action ProductPushedEvent;
    public event Action ProductPopedEvent;
    public int Count => _items.Count;
    public bool MaxCount => Count >= productPositions.Length;

    public Vector3 PickPoint => pickPoint.position;
   
    [SerializeField] protected Transform[] productPositions;
    [SerializeField] protected Transform productsParent;
    [SerializeField] protected Transform pickPoint;
    [SerializeField] protected ProductType storeType;

    private readonly Stack<Product> _items = new Stack<Product>();
    private StoreVisualizer _visualizer;

    private void Awake(){
        _visualizer = new StoreVisualizer(this, _items, productsParent, productPositions);
    }

    public virtual void Take(Product product){
        if (MaxCount || product.Type != storeType) return;

        _items.Push(product);
        ProductPushedEvent?.Invoke();
    }

    public Product Give(){
        if (Count <= 0) return null;
        
        var item = _items.Pop();
        ProductPopedEvent?.Invoke();
        return item;
    }
}
