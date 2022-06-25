using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Transform carryTransform;
    [SerializeField] private List<Shop> shops;
    [SerializeField] private Shop checkoutShop;
    [SerializeField] private GameObject maxUiLabel;
    
    public int FreeSpaceAmount => _basket.FreeSpaceAmount;
    public bool HasFreeSpace => _basket.FreeSpaceAmount > 0;

    public int RequiredQuantity;
    public Shop putShop;
    public bool OnDestination => !navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance
                                                        && (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f);
    
    private Basket _basket;
    private CustomerLogic _customerLogic;
 
    private void Awake(){
        _basket = new Basket(5, carryTransform, maxUiLabel);
        _customerLogic = new CustomerLogic(this);
    }

    private void Start(){
        _customerLogic.Play();
    }

    private void FixedUpdate(){
        _customerLogic.Update();
    }
    
    public void MoveTo(Vector3 target){
        navAgent.SetDestination(target);
    }
    
    public bool GetProduct(){
        if (!putShop.CanGet) return false;
      
        _basket.Put(putShop.Store.Get());
        return true;
    }
    
    public Shop GetRandomStore(){
        return shops[Random.Range(0, shops.Count)];
    }
    
    /*public void PutProduct(){
        if (!ChosenShop.Store.CanPut && !_basket.CanGet) return;
      
        ChosenShop.Store.Put(_basket.Get());
    }*/
}