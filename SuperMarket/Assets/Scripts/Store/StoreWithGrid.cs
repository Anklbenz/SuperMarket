using UnityEngine;

public class StoreWithGrid : Store
{
    private GridViewer _gridViewer;

    public StoreWithGrid(int maxCount, Transform parentContainer, Vector3 offsetVector, int width, int height) : base(maxCount){
        _gridViewer = new GridViewer(this, parentContainer, offsetVector, width, height);
    }
    
}