using Enums;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GetTrigger : MonoBehaviour
{
    [SerializeField] private Shop shop;
    public ProductType Type => shop.ProductType;
    
    public bool CanGet => shop.CanGet;
    
    public Product Get() => shop.Store.Get();
}