using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class Carrier
{
    public event Action PutInEvent;
    public event Action PutOutEvent;

    private const int MAX_COUNT = 5;
    private const int PUT_IN_DELAY = 100;
    private const int PUT_OUT_DELAY = 100;
    public int Count => _carryList.Count;
    public bool MaxCount => Count == MAX_COUNT;
    private bool ListEmpty => Count == 0;
    private readonly List<Product> _carryList;
    private bool _isPuttingIn, _isPuttingOut;
    
    private VerticalVisualizer _verticalVisualizer;

    public Carrier(Transform carryTransform, GameObject maxLabel){
        _carryList = new List<Product>();
        _verticalVisualizer = new VerticalVisualizer(this, carryTransform, _carryList, maxLabel);
    }

    public async void PutIn(IGive target){
        if (_isPuttingIn || !target.CanGive || MaxCount) return;

        var item = target.Give();
        _carryList.Add(item);
        PutInEvent?.Invoke();
        
        _isPuttingIn = true;
        await UniTask.Delay(PUT_IN_DELAY);
        _isPuttingIn = false;
    }

    public async void PutOut(ITake target){
        if (_isPuttingOut || ListEmpty || !target.CanTake || !FindProductByType(target.Type, out var item)) return;

        target.Take(item);
        _carryList.Remove(item);
        PutOutEvent?.Invoke();
        
        _isPuttingOut = true;
        await UniTask.Delay(PUT_OUT_DELAY);
        _isPuttingOut = false;
    }

    private bool FindProductByType(ProductType type, out Product product){
        product = _carryList.FindLast(item => item.Type == type);
        return product != null;
    }
}