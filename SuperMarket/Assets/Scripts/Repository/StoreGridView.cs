using UnityEngine;

public class StoreGridView : Repository
{
    private GridViewer _viewer;

    public StoreGridView(int maxCount, Transform parentContainer, Vector3 offsetVector, int width, int height) : base(maxCount){
        _viewer = new GridViewer(this, parentContainer, offsetVector, width, height);
    }
}


