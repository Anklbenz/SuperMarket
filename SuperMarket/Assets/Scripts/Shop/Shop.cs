using Enums;
using UnityEngine;

public abstract class Shop : MonoBehaviour
{
    [SerializeField] protected Transform activityPoint;
    [SerializeField] protected Transform parentContainer;
    [SerializeField] protected ProductType productType;
    
    public Vector3 PickPoint => activityPoint.position;
    public ProductType ProductType => productType;
    public virtual bool CanPut => Store.HasFreeSpace;
    public virtual bool CanGet => Store.Count > 0;
    
    public Store Store;
}