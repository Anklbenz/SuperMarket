using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.AI;

public class PickProductsBehavior// : ICustomerBehavior
{
    private readonly BehaviorManager _behaviorManager;
    private readonly List<Store> _stores;
    private Store _targetStore;
    private NavMeshAgent _navAgent;
    private CustomerState _currentState;

    public PickProductsBehavior(BehaviorManager behaviorManager, List<Store> stores, NavMeshAgent navAgent){
        _behaviorManager = behaviorManager;
        _stores = stores;
        _navAgent = navAgent;
    }
    public void Enter(){
        _targetStore = ChooseStore();
    }

    /*public void Update(){
        switch (_currentState){
            case(CustomerState.ChooseStore):
                _targetStore = ChooseStore();
                _currentState = CustomerState.MoveToStore;
                break;
            case (CustomerState.MoveToStore):
                if (!AgentOnPoint())
                    _behaviorManager.MoveTo(_targetStore.PickPoint);
                else
                    _currentState = CustomerState.PickProduct;
                break;
            case (CustomerState.PickProduct):
                _targetStore.Give();
                
            
        }
        if (!AgentOnPoint())
            _behaviorManager.MoveTo(_targetStore.PickPoint);
    }*/


    private bool AgentOnPoint(){
        if (_navAgent.pathPending &&
            _navAgent.remainingDistance <= _navAgent.stoppingDistance &&
            (_navAgent.hasPath && _navAgent.velocity.sqrMagnitude != 0f))
            return false;
        return true;
    }

    private Store ChooseStore(){
        var randomIndex = Random.Range(0, _stores.Count);
        return _stores[randomIndex];
    }
    public void Exit(){}
}
