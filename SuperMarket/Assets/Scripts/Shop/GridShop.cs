using UnityEngine;


public class GridShop : Shop
{
    [SerializeField] protected Vector3 offsetVector;
    [SerializeField] protected Vector2Int widthHeight;

    private void Awake(){
        Store = new StoreWithGrid(20, parentContainer, offsetVector, widthHeight.x, widthHeight.y);
    }
}