using UnityEngine;

public class Shop : MonoBehaviour
{
    public Vector3 PickPoint => activityPoint.position;
    public StoreDefinitePositionView StoreDefinitePositionView;

    [SerializeField] protected Transform[] productPositions;
    [SerializeField] protected Transform productsParent;
    [SerializeField] protected Transform activityPoint;

    private void Awake(){
       StoreDefinitePositionView = new StoreDefinitePositionView(productPositions.Length, productsParent, productPositions);
    }
}