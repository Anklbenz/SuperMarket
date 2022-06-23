using UnityEngine;
using Enums;

public class Shop : MonoBehaviour
{
    public Vector3 PickPoint => activityPoint.position;
    public Store Store;

    [SerializeField] protected Transform[] productPositions;
    [SerializeField] protected Transform productsParent;
    [SerializeField] protected Transform activityPoint;
    [SerializeField] protected ProductType storeType;

    private void Awake(){
        Store = new Store(productPositions.Length, storeType, productsParent, productPositions);
    }
}