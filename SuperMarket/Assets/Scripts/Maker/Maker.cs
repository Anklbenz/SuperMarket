using System.Collections.Generic;
using UnityEngine;

public class Maker : MonoBehaviour, IGive
{
    [SerializeField] private Product prefab;
    [SerializeField] private float growDelay;
    [SerializeField] private Transform poolParent;
    [SerializeField] private Transform[] growPoints;
    public int Count => _products.Count;
    public bool CanGive => _products.Count > 0;
    private int FruitAmount => growPoints.Length;
    private Timer _timer;
    private Stack<Product> _products;
    private PoolObjects<Product> _pool;

    public void Awake(){
        _products = new Stack<Product>();
        _pool = new PoolObjects<Product>(prefab, FruitAmount, true, poolParent);
        _timer = new Timer(growDelay);
        _timer.Start();
        _timer.TimerEvent += Create;
    }

    private void FixedUpdate() => _timer.Tick();
    public Product Give(){
        return Count > 0 ? _products.Pop() : null;
    }

    private void Create(){
        if (Count >= FruitAmount) return;

        var fruit = _pool.GetFreeElement();
        fruit.transform.position = growPoints[Count].position;
        _products.Push(fruit);
    }
}