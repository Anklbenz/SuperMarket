using Enums;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PutTrigger : MonoBehaviour
{
    [SerializeField] private Shop shop;

    public bool CanPut => shop.CanPut;
    public ProductType Type => shop.ProductType;
    public void Put(Product product) => shop.Store.Put(product);
}