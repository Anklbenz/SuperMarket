using UnityEngine;


public class GridShop : MonoBehaviour
{
    public Vector3 PickPoint => activityPoint.position;

    protected StoreGridView StoreGridView;

    [SerializeField] protected Transform parentContainer;
    [SerializeField] protected Transform activityPoint;
    [SerializeField] protected Vector3 offsetVector;
    [SerializeField] protected Vector2Int widthHeight;

    private void Awake(){
        StoreGridView = new StoreGridView(20, parentContainer, offsetVector, widthHeight.x, widthHeight.y);
    }
}