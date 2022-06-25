using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBin : Store
{
   private const int MAX_COUNT = 3;
   public override void Put(Product product){
      product.gameObject.SetActive(false);
   }

   public StoreBin() : base(MAX_COUNT){}
}
