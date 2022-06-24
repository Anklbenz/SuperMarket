using UnityEngine;

public class StoreDefinitePositionView : Repository
{
    private DefinitePositionViewer _viewer;

    public StoreDefinitePositionView(int maxCount, Transform basketTransform, Transform[] productsPositions) : base(maxCount){
        _viewer = new DefinitePositionViewer(this, basketTransform, productsPositions);
    }
}
