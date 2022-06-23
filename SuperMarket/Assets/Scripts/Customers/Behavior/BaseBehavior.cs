using UnityEngine;
using UnityEngine.AI;

public abstract class BaseBehavior
{
    protected Basket Basket;
    protected Shop SelectedShop;

    private readonly NavMeshAgent _navAgent;

    public BaseBehavior(NavMeshAgent navAgent, Basket basket){
        Basket = basket;
        _navAgent = navAgent;
    }

    protected Product GetProduct(){
        return SelectedShop.Store.CanGet ? SelectedShop.Store.Get() : null;
    }

    protected void PutProduct(Product product){
        if (!SelectedShop.Store.CanPut) return;
        
        SelectedShop.Store.Put(product);
    }
    
    protected void MoveTo(Vector3 target){
        _navAgent.SetDestination(target);
    }

    protected bool OnDestination(){
        return !_navAgent.pathPending &&
               _navAgent.remainingDistance <= _navAgent.stoppingDistance &&
               (!_navAgent.hasPath || _navAgent.velocity.sqrMagnitude == 0f);
    }
}

