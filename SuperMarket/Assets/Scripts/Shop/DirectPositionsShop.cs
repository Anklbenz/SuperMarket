using UnityEngine;

public class DirectPositionsShop : Shop
{
    [SerializeField] protected Transform[] productPositions;

    private void Awake(){
       Store = new StoreWithFixedPositions(productPositions.Length, parentContainer, productPositions);
    }
}