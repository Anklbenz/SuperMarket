using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BehaviorActions
{
   public int BasketFreeSpace => _basket.FreeSpace;
   public bool BasketHasFreeSpace => _basket.FreeSpace > 0;
   public bool OnDestination => !_navAgent.pathPending && _navAgent.remainingDistance <= _navAgent.stoppingDistance
                                                       && (!_navAgent.hasPath || _navAgent.velocity.sqrMagnitude == 0f);
   
   public Shop ChosenShop;
   public int RequiredQuantity;
   
   private readonly Basket _basket;
   private readonly List<Shop> _shops;
   public readonly Shop CheckoutShop;
   private readonly NavMeshAgent _navAgent;

   public BehaviorActions(NavMeshAgent navAgent, Basket basket, List<Shop> shops, Shop checkoutShop){
      _shops = shops;
      _basket = basket;
      _navAgent = navAgent;
      CheckoutShop = checkoutShop;
   }

   public Shop GetRandomStore(){
      return _shops[Random.Range(0, _shops.Count)];
   }

   public void MoveTo(Vector3 target){
      _navAgent.SetDestination(target);
   }
   
   public bool GetProduct(){
      if (!ChosenShop.Store.CanGet) return false;
      
      _basket.Put(ChosenShop.Store.Get());
      return true;
   }

   public void PutProduct(){
      if (!ChosenShop.Store.CanPut && !_basket.CanGet) return;
      
      ChosenShop.Store.Put(_basket.Get());
   }
}


