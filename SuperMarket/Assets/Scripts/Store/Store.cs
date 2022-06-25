using System;
using System.Collections.Generic;
using System.Linq;
using Enums;

public abstract class Store
{
    public event Action PutEvent;
    public event Action GetEvent;

    public List<Product> Items{ get; }
    public bool HasFreeSpace => Items.Count < MaxCount;
    public int FreeSpaceAmount => MaxCount - Count;
    public int MaxCount{ get; }
    public int Count => Items.Count;

    protected Store(int maxCount){
        MaxCount = maxCount;
        Items = new List<Product>();
    }

    public virtual void Put(Product product){
        if (product == null) return;
        Items.Add(product);
        PutEvent?.Invoke();
    }

    public Product Get(ProductType type){
        var product = Items.FindLast(item => item.Type == type);

        if (!product) return null;
        Items.Remove(product);
        GetEvent?.Invoke();
        return product;
    }

    public Product Get(){
        var product = Items.Last();
        if (!product) return null;

        Items.Remove(product);
        GetEvent?.Invoke();
        return product;
    }
}