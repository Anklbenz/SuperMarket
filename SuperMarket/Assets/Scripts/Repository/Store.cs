using Enums;
using UnityEngine;

public class Store : Repository
{
    public override bool CanPut => !OutOfSpace;
    public override bool CanGet => Items.Count > 0;
    private StoreViewer _viewer;
    private ProductType _storageType;
    
    public Store(int maxCount, ProductType storageType,  Transform basketTransform, Transform[] productsPositions) : base(maxCount){
        _storageType = storageType;
        _viewer = new StoreViewer(this,  basketTransform, productsPositions);
    }
}
