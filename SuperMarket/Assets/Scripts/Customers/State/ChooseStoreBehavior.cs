using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseStoreBehavior : ICustomerBehavior
{
    private List<Store> _stores;
    private BehaviorManager _behaviorManager;

    public ChooseStoreBehavior(BehaviorManager behaviorManager, List<Store> stores){
        _behaviorManager = behaviorManager;
        _stores = stores;
    }
    public void Enter(){
       ChooseStore();
    }

    public void Exit(){
        throw new System.NotImplementedException();
    }

    public void Update(){
        throw new System.NotImplementedException();
    }
    
    private Store ChooseStore(){
        var randomIndex = Random.Range(0, _stores.Count);
        return _stores[randomIndex];
    }
}
