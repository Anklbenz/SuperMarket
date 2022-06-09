using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;
using UnityEngine.AI;

public class BehaviorManager
{
   private readonly List<ICustomerBehavior> _behaviorsMap;
   private readonly NavMeshAgent _navAgent;
   private ICustomerBehavior _currentBehavior;
   private Store _targetStore;
   private List<Store> _stores;
   private CustomerState _currentState;

   /*public BehaviorManager(List<Store> stores, NavMeshAgent navAgent){
      _currentState = CustomerState.ChooseStore;
      _navAgent = navAgent;
      _behaviorsMap = new List<ICustomerBehavior>()
      {
         new PickProductsBehavior(this, stores)
      };
      
      SwitchBehavior<PickProductsBehavior>();
   }*/

   public void SwitchBehavior<T>() where T : ICustomerBehavior{
      var behavior = _behaviorsMap.FirstOrDefault(source => source is T);
      _currentBehavior?.Exit();
      _currentBehavior = behavior;
      _currentBehavior?.Enter();
   }

   public void Update(){
      switch (_currentState){
         
         case(CustomerState.ChooseStore):
            
            break;
         
      }
     
   }
   
   public void MoveTo(Vector3 target){
     _navAgent.SetDestination(target);
   }
   
   private Store ChooseStore(){
      var randomIndex = Random.Range(0, _stores.Count);
      return _stores[randomIndex];
   }
   
   /*private bool AgentOnPoint(){
      /*if (meshAgent.pathPending &&
          meshAgent.remainingDistance <= meshAgent.stoppingDistance &&
          (meshAgent.hasPath && meshAgent.velocity.sqrMagnitude != 0f))
         return false;
      return true;#1#
   }*/
}
