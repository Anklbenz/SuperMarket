using Enums;
using UnityEngine;

public class Bin : MonoBehaviour, IPut
{
    public ProductType Type => ProductType.All;
    public bool CanPut => true;
    public void Put(Product product){
        product.gameObject.SetActive(false);
    }
}
