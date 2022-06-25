using UnityEngine;

public class StoreWithFixedPositions : Store
{
    private FixedPositionsViewer _viewer;

    public StoreWithFixedPositions(int maxCount, Transform basketTransform, Transform[] productsPositions) : base(maxCount){
        _viewer = new FixedPositionsViewer(this, basketTransform, productsPositions);
    }
}
